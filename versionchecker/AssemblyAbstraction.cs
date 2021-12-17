using System;
using System.Reflection;

namespace VersionChecker
{
    /// <summary>
    /// This internal class is an abstraction for system.Reflection.Assembly calls. This helps
    /// with unit testing
    /// </summary>
    internal static class AssemblyAbstraction
    {
        /// <summary>
        /// Get the version of the library
        /// </summary>
        /// <param name="library">path and name of library</param>
        /// <returns>System.Version object for the version of the input library</returns>
        internal static Version GetLibraryVerison(string library)
        {
            return Assembly.LoadFile(library).GetName().Version;
        }
    }
}
