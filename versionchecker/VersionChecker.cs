using System;

namespace VersionChecker
{
    /// <summary>
    /// The VersionChecker class is used by 3rd party apps that have dependencies on IG-XL. These apps may ship versions
    /// of IG-XL libraries with them and at runtime need to ensure that the version they are using is compatibile with the
    /// smae library for the current version of IG-XL.
    /// </summary>
    public class VersionChecker
    {
        /// <summary>
        /// Retrieve the assembly version for a library.
        /// </summary>
        /// <param name="library">Path and name of the library</param>
        /// <returns>assembly version as a System.Version object</returns>
        public Version GetLibraryPathVersion(string library)
        {
            return AssemblyAbstraction.GetLibraryVerison(library);
        }

        /// <summary>
        /// Apply IG-XL assembly version logic (see comments in function) to determine if a library
        /// a library used locally is compatibile with the same library from the IGXLBIN.
        /// 
        /// The version check will occur on the library from the CWD and on the same library from IGXLBIN
        /// </summary>
        /// <param name="library">name of the library</param>
        /// <returns></returns>
        public bool CheckLibraryCompatibility(string library)
        {
            /*
             * Steps for checking if the library is compatible
             * 
             * Note:
             *  Major part is == Release major version
             *  Minor part is == Release minor version
             *  Build part is == Patch major version
             *  Revision part is == Patch minor version
             *  
             * Check the release version information
             * 
             * 1. Compare the major version of verAPPBIN with verIGXLBIN
             *      If they do not match then incompatible
             * 2. Compare the minor version of verAPPBIN with verIGXLBIN   
             *      if the verAPPBIN minor version is > verIGXLBIN then incompatible     
             *  
             *  Check the patch version information
             *  
             * 3. Compare the build version of verAPPBIN with verIGXLBIN
             *      If they do not match then incompatible
             * 4. Compare the revsion version of verAPPBIN with verIGXLBIN   
             *      if the verAPPBUILD revsion version is > verAPPBIN then incompatible
             */
            bool result = false;

            string localbinLibrary = Environment.CurrentDirectory + "\\" + library;
            string igxlbinLibrary;
            
            // If the IGXLBIN env variable is not set an ArgumentNullException is thrown.
            try
            {
                igxlbinLibrary = Environment.GetEnvironmentVariable("IGXLROOT") + "\\bin\\" + library;
            }
            catch (ArgumentNullException e)
            {
                throw new IgxlBinException("IGXLROOT environment variable not set.", e);
            }

            Version localVer = null;
            Version igxlVer = null;
            try
            {
                localVer = AssemblyAbstraction.GetLibraryVerison(localbinLibrary);
                igxlVer = AssemblyAbstraction.GetLibraryVerison(igxlbinLibrary);
            }
            catch (Exception e)
            {
                throw new AssemblyGetVersionException("Could not get version for " + library + ".", e);
            }

            if ((localVer == null) || (igxlVer == null))
            {
                return result;
            }

            if ((localVer.Major != igxlVer.Major) || (localVer.Build != igxlVer.Build))
            {
                result = false;
            }
            else if ((localVer.Minor > igxlVer.Minor) || (localVer.Revision > igxlVer.Revision))
            {
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
