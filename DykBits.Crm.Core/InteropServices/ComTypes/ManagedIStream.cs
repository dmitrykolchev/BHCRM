using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Security;

namespace DykBits.Crm.InteropServices.ComTypes
{
    class ManagedIStream : IStream
    {
        // Fields
        private Stream _ioStream;

        // Methods
        internal ManagedIStream(Stream ioStream)
        {
            if (ioStream == null)
            {
                throw new ArgumentNullException("ioStream");
            }
            this._ioStream = ioStream;
        }

        void IStream.Clone(out IStream streamCopy)
        {
            streamCopy = null;
            throw new NotSupportedException();
        }

        void IStream.Commit(int flags)
        {
            throw new NotSupportedException();
        }

        void IStream.CopyTo(IStream targetStream, long bufferSize, IntPtr buffer, IntPtr bytesWrittenPtr)
        {
            throw new NotSupportedException();
        }

        void IStream.LockRegion(long offset, long byteCount, int lockType)
        {
            throw new NotSupportedException();
        }

        [SecurityCritical]
        void IStream.Read(byte[] buffer, int bufferSize, IntPtr bytesReadPtr)
        {
            int val = this._ioStream.Read(buffer, 0, bufferSize);
            if (bytesReadPtr != IntPtr.Zero)
            {
                Marshal.WriteInt32(bytesReadPtr, val);
            }
        }

        void IStream.Revert()
        {
            throw new NotSupportedException();
        }

        [SecurityCritical]
        void IStream.Seek(long offset, int origin, IntPtr newPositionPtr)
        {
            SeekOrigin begin;
            switch (origin)
            {
                case 0:
                    begin = SeekOrigin.Begin;
                    break;

                case 1:
                    begin = SeekOrigin.Current;
                    break;

                case 2:
                    begin = SeekOrigin.End;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("origin");
            }
            long val = this._ioStream.Seek(offset, begin);
            if (newPositionPtr != IntPtr.Zero)
            {
                Marshal.WriteInt64(newPositionPtr, val);
            }
        }

        void IStream.SetSize(long libNewSize)
        {
            this._ioStream.SetLength(libNewSize);
        }

        void IStream.Stat(out System.Runtime.InteropServices.ComTypes.STATSTG streamStats, int grfStatFlag)
        {
            streamStats = new System.Runtime.InteropServices.ComTypes.STATSTG();
            streamStats.type = 2;
            streamStats.cbSize = this._ioStream.Length;
            streamStats.grfMode = 0;
            if (this._ioStream.CanRead && this._ioStream.CanWrite)
            {
                streamStats.grfMode |= 2;
            }
            else if (this._ioStream.CanRead)
            {
                streamStats.grfMode = 0;
            }
            else
            {
                if (!this._ioStream.CanWrite)
                    throw new IOException("stream object disposed");
                streamStats.grfMode |= 1;
            }
        }

        void IStream.UnlockRegion(long offset, long byteCount, int lockType)
        {
            throw new NotSupportedException();
        }

        [SecurityCritical]
        void IStream.Write(byte[] buffer, int bufferSize, IntPtr bytesWrittenPtr)
        {
            this._ioStream.Write(buffer, 0, bufferSize);
            if (bytesWrittenPtr != IntPtr.Zero)
            {
                Marshal.WriteInt32(bytesWrittenPtr, bufferSize);
            }
        }
    }
}
