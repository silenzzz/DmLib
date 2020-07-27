using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DmLib.Window
{
    public static class Transparency
    {
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool GetLayeredWindowAttributes(IntPtr hWnd,uint crKey, out byte bAlpha, uint dwFlags);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_ALPHA = 0x2;

        /// <summary>
        /// Sets the window transparency.
        /// </summary>
        /// <param name="p"> Target process. </param>
        /// <param name="opacityPercent"> Transparency precent. </param>
        public static void SetWindowTransparency(Process p, int opacityPercent)
        {
            SetWindowLong(p.MainWindowHandle, GWL_EXSTYLE,
                GetWindowLong(p.MainWindowHandle, GWL_EXSTYLE) ^ WS_EX_LAYERED);
            SetLayeredWindowAttributes(p.MainWindowHandle, 0, (byte)((255 * opacityPercent) / 100), LWA_ALPHA);
        }

        /// <summary>
        /// Gets the window transparency.
        /// </summary>
        /// <param name="p">The process.</param>
        /// <returns> Opacity precent. </returns>
        public static uint GetWindowTransparency(Process p)
        {
            //SetWindowLong(p.MainWindowHandle, GWL_EXSTYLE,
                //GetWindowLong(p.MainWindowHandle, GWL_EXSTYLE) ^ WS_EX_LAYERED);
            GetLayeredWindowAttributes(p.MainWindowHandle, 0, out byte alpha, 0);
            return (byte)((255 * alpha) / 100);
        }
    }
}
