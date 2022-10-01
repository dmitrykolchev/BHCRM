using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DykBits.Crm
{
    class NativeMethods
    {
        #region API declaration

        private const int ERROR_NO_ASSOCIATION = 1155;

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr hIcon);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SHGetFileInfo(string path, int fileAttributes, ref SHFILEINFO sfi, int cbFileInfo, int flags);

        public const int MAX_PATH = 260;

        public const int SHGFI_ICON = 0x000000100;                 // get icon
        public const int SHGFI_DISPLAYNAME = 0x000000200;          // get display name
        public const int SHGFI_TYPENAME = 0x000000400;             // get type name
        public const int SHGFI_ATTRIBUTES = 0x000000800;           // get attributes
        public const int SHGFI_ICONLOCATION = 0x000001000;         // get icon location
        public const int SHGFI_EXETYPE = 0x000002000;              // return exe type
        public const int SHGFI_SYSICONINDEX = 0x000004000;         // get system icon index
        public const int SHGFI_LINKOVERLAY = 0x000008000;          // put a link overlay on icon
        public const int SHGFI_SELECTED = 0x000010000;             // show icon in selected state
        public const int SHGFI_ATTR_SPECIFIED = 0x000020000;       // get only specified attributes
        public const int SHGFI_LARGEICON = 0x000000000;            // get large icon
        public const int SHGFI_SMALLICON = 0x000000001;            // get small icon
        public const int SHGFI_OPENICON = 0x000000002;             // get open icon
        public const int SHGFI_SHELLICONSIZE = 0x000000004;        // get shell size icon
        public const int SHGFI_PIDL = 0x000000008;                 // pszPath is a pidl
        public const int SHGFI_USEFILEATTRIBUTES = 0x000000010;    // use passed dwFileAttribute

        //#if (_WIN32_IE >= 0x0500)
        public const int SHGFI_ADDOVERLAYS = 0x000000020;          // apply the appropriate overlays
        public const int SHGFI_OVERLAYINDEX = 0x000000040;         // Get the index of the overlay
        // in the upper 8 bits of the iIcon 

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;                                        // out: icon
            public int iIcon;                                           // out: icon index
            public int dwAttributes;                                    // out: SFGAO_ flags
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;			                    // out: display name (or path)
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;				                    // out: type name
        }

        [Flags]
        public enum OpenAsInfoFlags : int
        {
            AllowRegistration = 0x00000001,             // enable the "always use this file" checkbox (NOTE if you don't pass this, it will be disabled)
            RegisterExt = 0x00000002,                   // do the registration after the user hits "ok"
            Exec = 0x00000004,                          // execute file after registering
            ForceRegistration = 0x00000008,             // force the "always use this file" checkbox to be checked (normally, you won't use the OAIF_ALLOW_REGISTRATION when you pass this)
            HideRegistration = 0x00000020,              // hide the "always use this file" checkbox
            UrlProtocol = 0x00000040,                   // the "extension" passed is actually a protocol, and open with should show apps registered as capable of handling that protocol
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct OPENASINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pcszFile;                 // [in] file name, or protocol name if
            //      OAIF_URL_PROTOCOL is set.
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pcszClass;                // [in] file class description. NULL means
            //      use pcszFile's extension. ignored
            //      if OAIF_URL_PROTOCOL is set.
            public OpenAsInfoFlags oaifInFlags;     // [in] input flags from OPEN_AS_INFO_FLAGS enumeration
        }

        //#if (NTDDI_VERSION >= NTDDI_VISTA)
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        public static extern int SHOpenWithDialog(IntPtr hwndParent, ref OPENASINFO poainfo);
        //endif

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr), In] string dllToLoad);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPWStr), In] string procedureName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetModuleFileName(IntPtr hModule, StringBuilder buffer, int length);

        #endregion

    }
}
