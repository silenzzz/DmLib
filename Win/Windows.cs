using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using System.Security.Principal;

namespace DmLib.Win
{
    public static class Windows
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);

        /// <summary>
        /// Is windows x64 bits architecture
        /// </summary>
        /// <returns> Result </returns>
        public static bool Is64Bit()
        {
            IsWow64Process(Process.GetCurrentProcess().Handle, out bool res);
            return res;
        }

        /// <summary>
        /// Get previleges for current user
        /// </summary>
        /// <returns> UserRole </returns>
        public static WindowsBuiltInRole GetCurrentUserPermisson()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? WindowsBuiltInRole.Administrator : WindowsBuiltInRole.User;
        }
    }
}
