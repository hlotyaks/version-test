using System;
using System.Reflection;

namespace VersionChecker
{
    internal static class AssemblyAbstraction
    {
        internal static Version GetLibraryVerison(string library)
        {
            return Assembly.LoadFile(library).GetName().Version;
        }
    }
}
