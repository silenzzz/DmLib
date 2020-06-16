using System;

namespace DmLib.Window
{
    public class ProcessNotExistsException : Exception
    {
        public ProcessNotExistsException()
        {
        }

        public ProcessNotExistsException(string message)
            : base(message)
        {
        }
    }
}
