namespace DmLib.Win
{
    public static class PathVariable
    {
        private readonly static SystemVariable variable = new SystemVariable("PATH");

        /// <summary>
        /// Append given path to PATH variable
        /// </summary>
        /// <param name="dir"> Directory path </param>
        /// <returns> Is added </returns>
        public static bool Add(string dir)
        {
            variable.Add(dir);
            return true;
        }

        /// <summary>
        /// Does PATH variable contains given path
        /// </summary>
        /// <param name="dir"> Directory </param>
        /// <returns> Contains </returns>
        public static bool Contains(string dir) => variable.Contains(dir);

        /// <summary>
        /// Get variable value
        /// </summary>
        /// <returns> Value </returns>
        public static string Get() => variable.Get();

        /// <summary>
        /// Remove given path from PATH variable
        /// </summary>
        /// <param name="dir"> Directory path </param>
        /// <returns> Is removed </returns>
        public static bool Remove(string dir)
        {
            variable.Remove(dir);
            return true;
        }

        /// <summary>
        /// Set PATH value
        /// </summary>
        /// <param name="s"> Value </param>
        /// <returns> Is setted </returns>
        public static bool Set(string s)
        {
            variable.Set(s);
            return true;
        }
    }
}
