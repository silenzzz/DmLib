using Microsoft.Win32;
using System;

namespace DmLib.Autorun
{
    public static class Autorun
    {
        public enum TARGET { MACHINE, USER }

        private const string FOLDER = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// Opens the registry key.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>Registry key</returns>
        public static RegistryKey OpenRegistryKey(TARGET target)
        {
            switch (target)
            {
                case TARGET.MACHINE: return Registry.LocalMachine.OpenSubKey(FOLDER, true);
                default: return Registry.CurrentUser.OpenSubKey(FOLDER, true);
            }
        }

        /// <summary>
        /// Does autorun contains given path.
        /// </summary>
        /// <param name="name"> Autorun added name </param>
        /// <returns> Result </returns>
        [Obsolete]
        public static bool Contains(string name)
        {
            var key = Registry.CurrentUser.OpenSubKey(FOLDER, true);
            return key.GetValue(name) != null;
        }

        /// <summary>
        /// Does autorun contains given path.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="target">The target.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified name]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(string name, TARGET target)
        {
            RegistryKey key = OpenRegistryKey(target);
            return key.GetValue(name) != null;
        }

        /// <summary>
        /// Add exe to autorun
        /// </summary>
        /// <param name="name"> Autorun name </param>
        /// <param name="exePath"> Executable path </param>
        /// <returns> Is added </returns>
        [Obsolete]
        public static bool Add(string name, string exePath)
        {
            var key = Registry.CurrentUser.OpenSubKey(FOLDER, true);
            try
            {
                key.SetValue(name, exePath);
            }
            catch (Exception e)
            {
                throw new AutorunException(e.Message);
            }
            return true;
        }

        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="exePath">The executable path.</param>
        /// <param name="target">The target.</param>
        /// <returns>Is added.</returns>
        /// <exception cref="AutorunException"></exception>
        public static bool Add(string name, string exePath, TARGET target)
        {
            RegistryKey key = OpenRegistryKey(target);
            try
            {
                key.SetValue(name, exePath);
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
        [Obsolete]
        public static bool Remove(string name)
        {
            var key = OpenRegistryKey(TARGET.USER);
            try
            {
                key.DeleteValue(name, true);
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
        /// <param name="target"> The target </param>
        /// <returns> Is removed </returns>
        public static bool Remove(string name, TARGET target)
        {
            var key = OpenRegistryKey(target);
            try
            {
                key.DeleteValue(name, true);
            }
            catch (Exception e)
            {
                throw new AutorunException(e.Message);
            }
            return true;
        }
    }
}
