using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace DykBits.Crm.InteropServices.ComTypes
{
    sealed class LockBytesImpl : ILockBytes, IDisposable
    {
        private MemoryStream _stream = new MemoryStream();

        private const int S_OK = 0;
        private const int E_NOTIMPL = unchecked((int)0x80000001);

        public LockBytesImpl()
        {
        }

        public Stream DetachInnerStream()
        {
            var result = this._stream;
            this._stream = null;
            return result;
        }

        #region ILockBytes Members

        public int ReadAt(long ulOffset, IntPtr pv, int cb, out int pcbRead)
        {
            byte[] buffer = new byte[cb];
            this._stream.Position = ulOffset;
            pcbRead = this._stream.Read(buffer, (int)ulOffset, cb);
            Marshal.Copy(buffer, 0, pv, cb);
            return S_OK;
        }

        public int WriteAt(long ulOffset, IntPtr pv, int cb, out int pcbWritten)
        {
            this._stream.Position = ulOffset;
            byte[] buffer = new byte[cb];
            Marshal.Copy(pv, buffer, 0, cb);
            this._stream.Write(buffer, 0, cb);
            pcbWritten = cb;
            return S_OK;
        }

        public int Flush()
        {
            this._stream.Flush();
            return S_OK;
        }

        public int SetSize(long cb)
        {
            this._stream.SetLength(cb);
            return S_OK;
        }

        public int LockRegion(long libOffset, ulong cb, uint dwLockType)
        {
            return E_NOTIMPL;
        }

        public int UnlockRegion(long libOffset, ulong cb, uint dwLockType)
        {
            return E_NOTIMPL;
        }

        public int Stat(IntPtr pstatstg, uint grfStatFlag)
        {
            if (pstatstg != IntPtr.Zero)
            {
                System.Runtime.InteropServices.ComTypes.STATSTG statstg = new System.Runtime.InteropServices.ComTypes.STATSTG();
                statstg.cbSize = this._stream.Length;
                statstg.clsid = Guid.Empty;
                statstg.grfLocksSupported = 0;
                statstg.grfMode = 0x00001012;
                statstg.grfStateBits = 0;
                statstg.type = 3;
                statstg.reserved = 0;
                Marshal.StructureToPtr(statstg, pstatstg, false);
            }
            return S_OK;
        }

        #endregion

        public void Save(string path)
        {
            this._stream.Position = 0;
            int read;
            byte[] buffer = new byte[64 * 1024];
            using (FileStream output = File.Create(path))
            {
                while ((read = this._stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    output.Write(buffer, 0, read);
                }
            }
        }

        public void Dispose()
        {
            if (this._stream != null)
            {
                this._stream.Dispose();
                this._stream = null;
            }
        }
    }
}
