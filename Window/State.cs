using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DmLib.Window
{
    public static class State
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;

        /// <summary>
        /// Top - window top most
        /// Untop - no top most? Yeah
        /// </summary>
        public enum WINDOW_STATE { TOP, UNTOP }

        /// <summary>
        /// Determines whether [has main window] [the specified p].
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns>
        ///   <c>true</c> if [has main window] [the specified p]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasMainWindow(Process p) => p.MainWindowHandle != IntPtr.Zero;

        /// <summary>
        /// Set process main window top state
        /// </summary>
        /// <param name="p"> Process </param>
        /// <param name="state"> Window state </param>
        public static void SetWindowState(Process p, WINDOW_STATE state)
        {
            try
            {
                if (state == WINDOW_STATE.TOP)
                {
                    SetWindowPos(p.MainWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
                else
                {
                    SetWindowPos(p.MainWindowHandle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
                }
            }
            catch (ArgumentException)
            {
                throw new ProcessNotExistsException("Process doesnt exists");
            }
        }
    }
}
