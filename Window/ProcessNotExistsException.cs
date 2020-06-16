using System;

namespace DmLib.Window
{
    class ProcessNotExistsException : Exception
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
