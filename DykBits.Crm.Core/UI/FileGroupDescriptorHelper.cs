using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using Com = System.Runtime.InteropServices.ComTypes;
using DykBits.Crm.InteropServices.ComTypes;

namespace DykBits.Crm.UI
{
    public sealed class FileGroupDescriptorHelper
    {
        private IDataObject _data;
        private NativeMethods.FILEDESCRIPTORW[] _files;

        public sealed class FileContent : IDisposable
        {
            private string _fileName;
            private Stream _stream;

            internal FileContent(string fileName, Stream stream)
            {
                this._fileName = fileName;
                stream.Position = 0;
                this._stream = stream;
            }

            public string FileName
            {
                get { return this._fileName; }
            }

            public Stream Stream
            {
                get { return this._stream; }
            }

            #region IDisposable Members

            public void Dispose()
            {
                if (this._stream != null)
                {
                    this._stream.Dispose();
                    this._stream = null;
                }
            }

            #endregion
        }


        public FileGroupDescriptorHelper(IDataObject data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (!GetDataPresent(data))
                throw new ArgumentException("doesn't support this format");
            this._data = data;
            Initialize();
        }

        public bool IsDataPresent
        {
            get
            {
                return GetDataPresent(this._data);
            }
        }

        public static bool GetDataPresent(IDataObject data)
        {
            IComDataObject cdo = (IComDataObject)(data);
            Com.IEnumFORMATETC enumFormatEtc = cdo.EnumFormatEtc(Com.DATADIR.DATADIR_GET);
            try
            {
                Com.FORMATETC[] fetc = new Com.FORMATETC[1];
                int[] rgelt = new int[1];

                while (enumFormatEtc.Next(1, fetc, rgelt) == 0)
                {
                    StringBuilder builder = new StringBuilder(1024);
                    NativeMethods.GetClipboardFormatName(fetc[0].cfFormat, builder, 1024);
                    System.Diagnostics.Debug.WriteLine(builder.ToString());
                }
            }
            finally
            {
                if (Marshal.IsComObject(enumFormatEtc))
                    Marshal.ReleaseComObject(enumFormatEtc);
            }
            return (data.GetDataPresent(NativeMethods.CFSTR_FILEDESCRIPTORW) || data.GetDataPresent(NativeMethods.CFSTR_FILEDESCRIPTOR))
                && data.GetDataPresent(NativeMethods.CFSTR_FILECONTENTS);
        }

        public int GetFileCount()
        {
            return this._files.Length;
        }

        public string GetFileName(int index)
        {
            if (index >= GetFileCount())
                throw new ArgumentOutOfRangeException("index");
            return this._files[index].cFileName;
        }

        private Com.STGMEDIUM GetData(int index)
        {
            IComDataObject cdo = (IComDataObject)((DataObject)this._data);
            Com.IEnumFORMATETC enumFormatEtc = cdo.EnumFormatEtc(Com.DATADIR.DATADIR_GET);
            try
            {
                Com.FORMATETC[] fetc = new Com.FORMATETC[1];
                int[] rgelt = new int[1];

                while (enumFormatEtc.Next(1, fetc, rgelt) == 0)
                {
                    StringBuilder builder = new StringBuilder(1024);
                    NativeMethods.GetClipboardFormatName(fetc[0].cfFormat, builder, 1024);
                    if (builder.ToString() == NativeMethods.CFSTR_FILECONTENTS)
                    {
                        Com.STGMEDIUM medium;
                        fetc[0].lindex = index;
                        cdo.GetData(ref fetc[0], out medium);
                        return medium;
                    }
                }
                throw new InvalidOperationException();
            }
            finally
            {
                Marshal.ReleaseComObject(enumFormatEtc);
            }
        }

        private void GetFileCopy(Com.STGMEDIUM medium, IStorage stgDest)
        {
            IStorage stgSource = (IStorage)Marshal.GetObjectForIUnknown(medium.unionmember);
            try
            {
                int result = stgSource.CopyTo(0, IntPtr.Zero, IntPtr.Zero, stgDest);
                if (result != 0)
                    throw new System.ComponentModel.Win32Exception(result);
                result = stgDest.Commit(0);
                if (result != 0)
                    throw new System.ComponentModel.Win32Exception(result);
            }
            finally
            {
                Marshal.ReleaseComObject(stgSource);
            }
        }

        private void GetFileCopy(Com.STGMEDIUM medium, Com.IStream stmDest)
        {
            Com.IStream stmSource;
            if ((medium.tymed & Com.TYMED.TYMED_ISTREAM) != 0)
            {
                stmSource = (Com.IStream)Marshal.GetObjectForIUnknown(medium.unionmember);
            }
            else if ((medium.tymed & Com.TYMED.TYMED_HGLOBAL) != 0)
            {
                int result = NativeMethods.CreateStreamOnHGlobal(medium.unionmember, false, out stmSource);
                if (result != 0)
                    throw new System.ComponentModel.Win32Exception(result);
            }
            else
                throw new InvalidOperationException("unsupported medium");
            try
            {
                Com.STATSTG stat;
                stmSource.Stat(out stat, 0);
                stmSource.CopyTo(stmDest, stat.cbSize, IntPtr.Zero, IntPtr.Zero);
            }
            finally
            {
                Marshal.ReleaseComObject(stmSource);
            }
        }

        public void SaveFileContent(int index, string path)
        {
            Com.STGMEDIUM medium = GetData(index);
            try
            {
                if ((medium.tymed & System.Runtime.InteropServices.ComTypes.TYMED.TYMED_ISTORAGE) != 0)
                {
                    IStorage stgDest;
                    int result = NativeMethods.StgCreateDocfile(path, 0x00001012, 0, out stgDest);
                    if (result != 0)
                        throw new System.ComponentModel.Win32Exception(result);
                    try
                    {
                        GetFileCopy(medium, stgDest);
                    }
                    finally
                    {
                        Marshal.ReleaseComObject(stgDest);
                    }
                }
                else if ((medium.tymed & (Com.TYMED.TYMED_ISTREAM | Com.TYMED.TYMED_HGLOBAL)) != 0)
                {
                    using (FileStream output = File.Create(path))
                    {
                        ManagedIStream stmDest = new ManagedIStream(output);
                        GetFileCopy(medium, stmDest);
                    }
                }
                else
                    throw new InvalidOperationException("unsupported medium");
            }
            finally
            {
                NativeMethods.ReleaseStgMedium(ref medium);
            }
        }

        public FileContent ReadFileContent(int index)
        {
            Com.STGMEDIUM medium = GetData(index);
            try
            {
                if ((medium.tymed & System.Runtime.InteropServices.ComTypes.TYMED.TYMED_ISTORAGE) != 0)
                {
                    IStorage stgDest;
                    using (LockBytesImpl lockBytes = new LockBytesImpl())
                    {
                        int result = NativeMethods.StgCreateDocfileOnILockBytes(lockBytes, 0x00001012, 0, out stgDest);
                        if (result != 0)
                            throw new System.ComponentModel.Win32Exception(result);
                        try
                        {
                            GetFileCopy(medium, stgDest);
                            return new FileContent(this._files[index].cFileName, lockBytes.DetachInnerStream());
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(stgDest);
                        }
                    }
                }
                else if ((medium.tymed & (Com.TYMED.TYMED_ISTREAM | Com.TYMED.TYMED_HGLOBAL)) != 0)
                {
                    MemoryStream buffer = new MemoryStream();
                    ManagedIStream stmDest = new ManagedIStream(buffer);
                    GetFileCopy(medium, stmDest);
                    return new FileContent(this._files[index].cFileName, buffer);
                }
                else
                    throw new InvalidOperationException("unsupported medium");
            }
            finally
            {
                NativeMethods.ReleaseStgMedium(ref medium);
            }
        }

        public static void Save(Stream stream, string path)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            stream.Position = 0;
            using (FileStream output = File.Create(path))
            {
                byte[] buffer = new byte[64 * 1024];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    output.Write(buffer, 0, read);
                }
            }
        }

        private void Initialize()
        {
            bool unicode = this._data.GetDataPresent(NativeMethods.CFSTR_FILEDESCRIPTORW);
            Stream stream = unicode ? (Stream)this._data.GetData(NativeMethods.CFSTR_FILEDESCRIPTORW) : (Stream)this._data.GetData(NativeMethods.CFSTR_FILEDESCRIPTOR);
            IntPtr ptr = Marshal.AllocHGlobal((int)stream.Length);
            if (ptr == IntPtr.Zero)
                throw new OutOfMemoryException();
            try
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                Marshal.Copy(buffer, 0, ptr, buffer.Length);
                NativeMethods.FILEGROUPDESCRIPTOR fgd = (NativeMethods.FILEGROUPDESCRIPTOR)Marshal.PtrToStructure(ptr, typeof(NativeMethods.FILEGROUPDESCRIPTOR));
                NativeMethods.FILEDESCRIPTORW[] fd = new NativeMethods.FILEDESCRIPTORW[fgd.cItems];
                if (unicode)
                {
                    int offset = Marshal.SizeOf(typeof(NativeMethods.FILEGROUPDESCRIPTOR));
                    for (int index = 0; index < fgd.cItems; ++index)
                    {
                        fd[index] = (NativeMethods.FILEDESCRIPTORW)Marshal.PtrToStructure(ptr + offset, typeof(NativeMethods.FILEDESCRIPTORW));
                        offset += Marshal.SizeOf(typeof(NativeMethods.FILEDESCRIPTORW));
                    }
                }
                else
                {
                    int offset = Marshal.SizeOf(typeof(NativeMethods.FILEGROUPDESCRIPTOR));
                    for (int index = 0; index < fgd.cItems; ++index)
                    {
                        NativeMethods.FILEDESCRIPTORA temp = (NativeMethods.FILEDESCRIPTORA)Marshal.PtrToStructure(ptr + offset, typeof(NativeMethods.FILEDESCRIPTORA));
                        offset += Marshal.SizeOf(typeof(NativeMethods.FILEDESCRIPTORA));
                        fd[index] = new NativeMethods.FILEDESCRIPTORW(ref temp);
                    }
                }
                this._files = fd;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
