using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

namespace DmLib.Window
{
    public static class Borders
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nHeight, int nWidth, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern long GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        /// <summary>
        /// Edits the window.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static bool EditWindow(Process p, int X, int Y, int height, int width)
        {
            return MoveWindow(p.MainWindowHandle, X, Y,
               height + Y, width + X, true);
        }

        /// <summary>
        /// Edits the window.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="repaint">if set to <c>true</c> [repaint].</param>
        /// <returns></returns>
        public static bool EditWindow(Process p, int X, int Y, int height, int width, bool repaint)
        {
            return MoveWindow(p.MainWindowHandle, X, Y,
               height + Y, width + X, repaint);
        }

        /// <summary>Sets the size of the window.</summary>
        /// <param name="p">The p.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <returns></returns>
        public static bool SetWindowSize(Process p, int height, int width)
        {
            Rectangle current = GetWindowRectangle(p);
            return MoveWindow(p.MainWindowHandle, current.X, current.Y,
               height + current.Y, width + current.X, true);
        }

        /// <summary>
        /// Sets the size of the window.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="repaint">if set to <c>true</c> [repaint].</param>
        /// <returns></returns>
        public static bool SetWindowSize(Process p, int height, int width, bool repaint)
        {
            Rectangle current = GetWindowRectangle(p);
            return MoveWindow(p.MainWindowHandle, current.X, current.Y,
               height + current.Y, width + current.X, repaint);
        }

        /// <summary>
        /// Moves the window.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <returns></returns>
        public static bool MoveWindow(Process p, int X, int Y)
        {
            Rectangle current = GetWindowRectangle(p);
            return MoveWindow(p.MainWindowHandle, X, Y, current.Height + Y, current.Width + X, true);
        }

        /// <summary>
        /// Moves the window.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="repaint">if set to <c>true</c> [repaint].</param>
        /// <returns></returns>
        public static bool MoveWindow(Process p, int X, int Y, bool repaint)
        {
            Rectangle current = GetWindowRectangle(p);
            return MoveWindow(p.MainWindowHandle, X, Y, current.Height + Y, current.Width + X, repaint);
        }

        /// <summary>
        /// Gets the window rectangle.
        /// </summary>
        /// <param name="p">Process</param>
        /// <returns>Window rectangle</returns>
        public static Rectangle GetWindowRectangle(Process p)
        {
            Rectangle rectangle = new Rectangle();
            GetWindowRect(p.MainWindowHandle, ref rectangle);
            return rectangle;
        }
    }
}
