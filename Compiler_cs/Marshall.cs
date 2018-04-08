using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Compiler_cs
{
    class ConstCharPtrMarshaler : ICustomMarshaler
    {
        public void CleanUpManagedData(object ManagedObj)
        {
            throw new NotImplementedException();
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            throw new NotImplementedException();
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            return IntPtr.Zero;
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return Marshal.PtrToStringAnsi(pNativeData);
        }
        static readonly ConstCharPtrMarshaler instance = new ConstCharPtrMarshaler();
        public static ICustomMarshaler GetInstance(string cookie) { return instance; }
    }
    static class Marshall
    {
        [DllImport("PostFix.dll", CallingConvention = CallingConvention.Cdecl)]
        //[return : MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ConstCharPtrMarshaler))]
        //[return : MarshalAs(UnmanagedType.)]
        extern public static char[] polish(char[] s);

    }
}
