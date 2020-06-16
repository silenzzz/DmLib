using System;

namespace DmLib.Winforms
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
