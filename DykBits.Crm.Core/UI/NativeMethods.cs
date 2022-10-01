using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using Com = System.Runtime.InteropServices.ComTypes;
using DykBits.Crm.InteropServices.ComTypes;

namespace DykBits.Crm.UI
{
    class NativeMethods
    {
        private const string User32Dll = "user32.dll";
        [DllImport(User32Dll)]
        public static extern IntPtr LoadImage(IntPtr hInstance, IntPtr resourceId, int uType, int cxDesired, int cyDesired, int fuLoad);

        private const int IDI_APPLICATION = 32512;
        private const int IDI_HAND = 32513;
        private const int IDI_QUESTION = 32514;
        private const int IDI_EXCLAMATION = 32515;
        private const int IDI_ASTERISK = 32516;
        private const int IDI_WINLOGO = 32517;
        private const int IDI_SHIELD = 32518;
        private const int IDI_WARNING = IDI_EXCLAMATION;
        private const int IDI_ERROR = IDI_HAND;
        private const int IDI_INFORMATION = IDI_ASTERISK;

        private const int IMAGE_BITMAP = 0;
        private const int IMAGE_CURSOR = 1;
        private const int IMAGE_ICON = 2;

        private const int LR_SHARED = 0x00008000;

        public static BitmapSource LoadSystemIcon()
        {
            BitmapSource source = Imaging.CreateBitmapSourceFromHIcon(System.Drawing.SystemIcons.Error.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return source;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetCapture();

        #region API declarations

        [StructLayout(LayoutKind.Sequential)]
        public struct SIZEL
        {
            public int cx;
            public int cy;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTL
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FILEDESCRIPTORW
        {
            public uint dwFlags;
            public Guid clsid;
            public SIZEL sizel;
            public POINTL pointl;
            public uint dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;

            public FILEDESCRIPTORW(ref FILEDESCRIPTORA that)
            {
                this.dwFlags = that.dwFlags;
                this.clsid = that.clsid;
                this.sizel = that.sizel;
                this.pointl = that.pointl;
                this.dwFileAttributes = that.dwFileAttributes;
                this.ftCreationTime = that.ftCreationTime;
                this.ftLastAccessTime = that.ftLastAccessTime;
                this.ftLastWriteTime = that.ftLastWriteTime;
                this.nFileSizeHigh = that.nFileSizeHigh;
                this.nFileSizeLow = that.nFileSizeLow;
                this.cFileName = that.cFileName;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct FILEDESCRIPTORA
        {
            public uint dwFlags;
            public Guid clsid;
            public SIZEL sizel;
            public POINTL pointl;
            public uint dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FILEGROUPDESCRIPTOR
        {
            public uint cItems;
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst=1)]
            //public FILEDESCRIPTOR[] fgd;
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetClipboardFormatName(int format, StringBuilder lpString, int cchMax);

        [DllImport("ole32.dll")]
        public static extern void ReleaseStgMedium(ref Com.STGMEDIUM medium);

        [DllImport("ole32.dll", CharSet = CharSet.Unicode)]
        public static extern int StgCreateDocfile([MarshalAs(UnmanagedType.LPWStr)] string name, int grfMode, int reserved, out IStorage stgOpen);

        [DllImport("ole32.dll")]
        public static extern int StgCreateDocfileOnILockBytes(ILockBytes plkbyt, int grfMode, int reserved, out IStorage stgOpen);

        [DllImport("ole32.dll")]
        public static extern int CreateILockBytesOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out ILockBytes ppLkbyt);

        [DllImport("ole32.dll")]
        public static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, out Com.IStream ppstm);

        //[DllImport("ole32.dll")]
        //public static extern int GetHGlobalFromStream(Com.IStream pstm, out IntPtr phGlobal);

        //[DllImport("kernel32.dll")]
        //public static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

        //[DllImport("kernel32.dll")]
        //public static extern IntPtr GlobalLock(IntPtr hGlobal);

        //[DllImport("kernel32.dll")]
        //public static extern bool GlobalUnlock(IntPtr hGlobal);

        //[DllImport("kernel32.dll")]
        //public static extern IntPtr GlobalFree(IntPtr hGlobal);

        public const string CFSTR_FILEDESCRIPTORW = "FileGroupDescriptorW";
        public const string CFSTR_FILEDESCRIPTOR = "FileGroupDescriptor";
        public const string CFSTR_FILECONTENTS = "FileContents";

        #endregion
    }
}
