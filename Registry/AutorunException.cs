using System;

namespace DmLib.Autorun
{
    public class AutorunException : Exception
    {
        public AutorunException()
        {
        }

        public AutorunException(string message)
            : base(message)
        {
        }
    }
}
