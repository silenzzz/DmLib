using Microsoft.Win32;
using System;

namespace DmLib.Autorun
{
    public static class Autorun
    {
        /// <summary>
        /// Does autorun contains given path
        /// </summary>
        /// <param name="name"> Autorun added name </param>
        /// <returns> Result </returns>
        public static bool Contains(string name)
        {
            var rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return rkApp.GetValue(name) != null;
        }

        /// <summary>
        /// Add exe to autorun
        /// </summary>
        /// <param name="name"> Autorun name </param>
        /// <param name="exePath"> Executable path </param>
        /// <returns> Is added </returns>
        public static bool Add(string name, string exePath)
        {
            var rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            try
            {
                rkApp.SetValue(name, exePath);
            }
            catch (Exception e)
            {
                throw new AutorunException(e.Message);
            }
            return true;
        }

        /// <summary>
        /// Remove by autorun name
        /// </summary>
        /// <param name="name"> Autorun name (Which you used in add as 1st arg) </param>
        /// <returns> Is removed </returns>
        public static bool Remove(string name)
        {
            var rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            try
            {
                rkApp.DeleteValue(name, true);
            }
            catch (Exception e)
            {
                throw new AutorunException(e.Message);
            }
            return true;
        }
    }
}
