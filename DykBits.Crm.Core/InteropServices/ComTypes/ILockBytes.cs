using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DykBits.Crm.InteropServices.ComTypes
{
    [ComImport]
    [Guid("0000000a-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ILockBytes
    {
        [PreserveSig]
        int ReadAt(long ulOffset, IntPtr pv, int cb, out int pcbRead);
        [PreserveSig]
        int WriteAt(long ulOffset, IntPtr pv, int cb, out int pcbWritten);
        [PreserveSig]
        int Flush();
        [PreserveSig]
        int SetSize(long cb);
        [PreserveSig]
        int LockRegion(long libOffset, ulong cb, uint dwLockType);
        [PreserveSig]
        int UnlockRegion(long libOffset, ulong cb, uint dwLockType);
        [PreserveSig]
        int Stat(IntPtr pstatstg, uint grfStatFlag);
    }
}
