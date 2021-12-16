using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace app
{
    class Program
    {
        iface.IClass1 _ifc;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            _ifc.Value = 1;
            _ifc.DoSomething();
            //_ifc.DoSomething2();
        }

        Program()
        {
            _ifc = new iface.Class1();

            string locallibrary = Environment.CurrentDirectory + @"\iface.dll";

            var dc = new VersionChecker.VersionChecker();
            var verIGXLBIN = dc.GetLibraryPathVersion(locallibrary);              // the version from IGXLBIN
            var verAPPBIN = dc.GetLibraryPathVersion(locallibrary);      // the version from the app bin
            var verAPPBUILD = dc.GetLibraryBuildVersion("");            // the version the app was built with

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

            bool IsCompatible = dc.CheckLibraryCompatibility("iface.dll");
        }
    }
}
