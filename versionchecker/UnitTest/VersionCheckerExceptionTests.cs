using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionChecker;
using TypeMock.ArrangeActAssert;

namespace VersionChecker.Test
{
    [TestClass]
    [Isolated]
    public class VersionCheckerExceptionTests
    {
        string library = "dummy.dll";
        string path = "C:";
        string mainpath = "C:\\igxl";

        [TestMethod]
        [ExpectedException(typeof(IgxlBinException))]
        public void VersionTest_GetEnvironmentVariable_Exception()
        {

            Version appversion = new Version(1, 0, 1, 2);
            Version mainversion = new Version(1, 0, 1, 1);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => Environment.CurrentDirectory).WillReturn(path);
            Isolate.WhenCalled(() => Environment.GetEnvironmentVariable("IGXLBIN")).WillThrow(new ArgumentNullException());

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

        }

        [TestMethod]
        [ExpectedException(typeof(AssemblyGetVersionException))]
        public void VersionTest_GetLibraryVerison_Exception()
        {

            Version appversion = new Version(1, 0, 1, 2);
            Version mainversion = new Version(1, 0, 1, 1);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => Environment.CurrentDirectory).WillReturn(path);
            Isolate.WhenCalled(() => Environment.GetEnvironmentVariable("IGXLBIN")).WillReturn(mainpath);

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillThrow(new ArgumentException());

            bool result = vc.CheckLibraryCompatibility(library);

        }
    }
}
