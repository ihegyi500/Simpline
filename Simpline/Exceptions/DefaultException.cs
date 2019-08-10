using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCPS
{
    public class DefaultException : Exception
    {
        public DefaultException() { }
        public DefaultException(String message) : base(message)
        {

        }
        public DefaultException(String message, Exception inner) : base(message, inner)
        {
        }

    }
}

