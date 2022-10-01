using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace DykBits.Crm
{
    public enum IconSize
    {
        Small = 0,
        Normal = 1,
        Large = 2
    }

    public sealed class Shell
    {
        private static ArrayList tempFiles = new ArrayList();


        public sealed class ShellIcon
        {
            private static readonly Dictionary<IconKey, BitmapSource> _icons = new Dictionary<IconKey, BitmapSource>();

            private ShellIcon()
            {
            }

            public static BitmapSource GetShellIcon(string extension, IconSize iconSize)
            {
                IconKey key = new IconKey(extension, iconSize);
                BitmapSource source;
                if (!_icons.TryGetValue(key, out source))
                {
                    IntPtr hIcon = GetShellIconInternal(extension, iconSize);
                    if (hIcon != IntPtr.Zero)
                    {
                        try
                        {
                            Int32Rect rect = new Int32Rect(0, 0, 16 * ((int)iconSize + 1), 16 * ((int)iconSize + 1));
                            source = Imaging.CreateBitmapSourceFromHIcon(hIcon, rect, BitmapSizeOptions.FromEmptyOptions());
                            _icons.Add(key, source); 
                        }
                        catch
                        {
                            return null;
                        }
                        finally
                        {
                            NativeMethods.DestroyIcon(hIcon);
                        }
                    }
                }
                return source;
            }

            private static IntPtr GetShellIconInternal(string extension, IconSize iconSize)
            {
                NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();

                int flags = NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_USEFILEATTRIBUTES;
                if (iconSize == IconSize.Small)
                    flags |= NativeMethods.SHGFI_SMALLICON;
                else if (iconSize == IconSize.Large)
                    flags |= NativeMethods.SHGFI_LARGEICON;
                IntPtr handle = NativeMethods.SHGetFileInfo(extension, 0, ref shfi, Marshal.SizeOf(typeof(NativeMethods.SHFILEINFO)), flags);
                return shfi.hIcon;
            }

            private class IconKey
            {
                private string _extension;
                private IconSize _iconSize;
                private int _hashCode;

                public IconKey(string extension, IconSize iconSize)
                {
                    this._extension = extension;
                    this._iconSize = iconSize;
                    this._hashCode = extension.GetHashCode() ^ iconSize.GetHashCode();
                }

                public override int GetHashCode()
                {
                    return this._hashCode;
                }

                public override bool Equals(object obj)
                {
                    if (obj is IconKey)
                    {
                        IconKey that = (IconKey)obj;
                        if (this._iconSize == that._iconSize)
                            return string.Compare(this._extension, that._extension, StringComparison.OrdinalIgnoreCase) == 0;
                    }
                    return false;
                }
            }
        }
    }
}
