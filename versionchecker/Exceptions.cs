using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionChecker
{
    public class IgxlBinException : Exception
    {
        public IgxlBinException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class AssemblyGetVersionException : Exception
    {
        public AssemblyGetVersionException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
