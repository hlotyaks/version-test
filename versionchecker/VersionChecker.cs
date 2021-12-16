using System;
using System.Reflection;

namespace VersionChecker
{
    public class VersionChecker
    {
        public Version GetLibraryPathVersion(string library)
        {
            return Assembly.LoadFile(library).GetName().Version;
        }

        public Version GetLibraryBuildVersion(string library)
        {
            // need to get this info from the app manifest file that is part of the app metadata. don't know how to do this yet...
            return null;
        }

        public bool CheckLibraryCompatibility(string library)
        {
            /*
             * Steps for checking if the library is compatible
             * 1. Compare the major version of verAPPBUILD with verAPPBIN
             *      If they do not match then incompatible
             * 2. Compare the major version of verAPPBUILD with verIGXLBIN
             *      If they do not match then incompatible
             * 3. Compare the minor version of verAPPBUILD with verAPPBIN   
             *      if the verAPPBUILD minor version is > verAPPBIN then incompatible
             * 4. Compare the minor version of verAPPBUILD with verIGXLBIN   
             *      if the verAPPBUILD minor version is > verIGXLBIN then incompatible  
             *      
             *      
             * 5. Compare the build version of verAPPBUILD with verAPPBIN
             *      If they do not match then incompatible
             * 6. Compare the build version of verAPPBUILD with verIGXLBIN
             *      If they do not match then incompatible
             * 7. Compare the revsion version of verAPPBUILD with verAPPBIN   
             *      if the verAPPBUILD revsion version is > verAPPBIN then incompatible
             * 8. Compare the revsion version of verAPPBUILD with verIGXLBIN   
             *      if the verAPPBUILD revsion version is > verIGXLBIN then incompatible  
             */

            string localbinLibrary = Environment.CurrentDirectory + $@"\{library}"; ;
            string igxlbinLibrary = Environment.GetEnvironmentVariable("IGXLBIN") + $@"\{library}";

            Version localVer = AssemblyAbstraction.GetLibraryVerison(localbinLibrary);
            Version igxlVer = AssemblyAbstraction.GetLibraryVerison(igxlbinLibrary);

            if ((localVer.Major != igxlVer.Major) && (localVer.Build != igxlVer.Build))
                return false;

            if ((localVer.Minor > igxlVer.Minor) && (localVer.Revision > igxlVer.Revision))
                return false;

            return true;
        }
    }
}
