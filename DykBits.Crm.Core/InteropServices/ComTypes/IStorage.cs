using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace DykBits.Crm.InteropServices.ComTypes
{
    [ComImport]
    [Guid("0000000b-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStorage
    {

        //typedef [unique] IStorage * LPSTORAGE;

        //typedef struct tagRemSNB
        //{
        //    unsigned long ulCntStr;
        //    unsigned long ulCntChar;
        //    [size_is(ulCntChar)] OLECHAR rgString[];
        //} RemSNB;

        //typedef [unique] RemSNB * wireSNB;
        //typedef [wire_marshal(wireSNB)] OLECHAR **SNB;

        [PreserveSig]
        int CreateStream(
            [MarshalAs(UnmanagedType.LPWStr)]string pwcsName,
            int grfMode,
            int reserved1,
            int reserved2,
            out IStream ppstm);

        [PreserveSig]
        int OpenStream(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
            IntPtr reserved1,
            int grfMode,
            int reserved2,
            out IStream ppstm);

        [PreserveSig]
        int CreateStorage(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
            int grfMode,
            int reserved1,
            int reserved2,
            out IStorage ppstg);

        [PreserveSig]
        int OpenStorage(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
            IStorage pstgPriority,
            int grfMode,
            IntPtr snbExclude, //SNB snbExclude,
            int reserved,
            out IStorage ppstg);

        [PreserveSig]
        int CopyTo(
            int ciidExclude,
            IntPtr rgiidExclude, //ref Guid rgiidExclude,
            IntPtr snbExclude, //SNB snbExclude,
            IStorage pstgDest);

        [PreserveSig]
        int MoveElementTo(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
            IStorage pstgDest,
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName,
            int grfFlags);

        [PreserveSig]
        int Commit(int grfCommitFlags);

        [PreserveSig]
        int Revert();

        [PreserveSig]
        int EnumElements(
            int reserved1,
            IntPtr reserved2,
            int reserved3,
            out IntPtr ppenum); //out IEnumSTATSTG ppenum);

        [PreserveSig]
        int DestroyElement(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

        [PreserveSig]
        int RenameElement(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsOldName,
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsNewName);

        [PreserveSig]
        int SetElementTimes(
            [MarshalAs(UnmanagedType.LPWStr)] string pwcsName,
            [In]ref System.Runtime.InteropServices.ComTypes.FILETIME pctime,
            [In]ref System.Runtime.InteropServices.ComTypes.FILETIME patime,
            [In]ref System.Runtime.InteropServices.ComTypes.FILETIME pmtime);

        [PreserveSig]
        int SetClass(
            [In]ref Guid clsid);

        [PreserveSig]
        int SetStateBits(
            int grfStateBits,
            int grfMask);

        [PreserveSig]
        int Stat(
            out  System.Runtime.InteropServices.ComTypes.STATSTG pstatstg,
            int grfStatFlag);
    }
}
