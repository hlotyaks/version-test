using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionChecker;
using TypeMock.ArrangeActAssert;

namespace VersionChecker.Test
{
    [TestClass]
    [Isolated]
    public class VersionCheckerTests
    {
        string library = "dummy.dll";
        string path = "C:";
        string mainpath = "C:\\igxl";

        [TestInitialize]
        public void TestSetup()
        {
            Isolate.WhenCalled(() => Environment.CurrentDirectory).WillReturn(path);
            Isolate.WhenCalled(() => Environment.GetEnvironmentVariable("IGXLBIN")).WillReturn(mainpath);
        }

        [TestMethod]
        public void VersionTest_SameMajor()
        {

            Version appversion = new Version(1, 0, 0, 0);
            Version mainversion = new Version(1, 0, 0, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void VersionTest_MainBumpMinor()
        {

            Version appversion = new Version(1, 0, 0, 0);
            Version mainversion = new Version(1, 1, 0, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void VersionTest_AppBumpMinor()
        {

            Version appversion = new Version(1, 1, 0, 0);
            Version mainversion = new Version(1, 0, 0, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void VersionTest_MainBumpMajor()
        {

            Version appversion = new Version(1, 0, 0, 0);
            Version mainversion = new Version(2, 0, 0, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void VersionTest_AppBumpMajor()
        {

            Version appversion = new Version(2, 0, 0, 0);
            Version mainversion = new Version(1, 0, 0, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void VersionTest_SameBuild()
        {

            Version appversion = new Version(1, 0, 1, 0);
            Version mainversion = new Version(1, 0, 1, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void VersionTest_MainBumpBuild()
        {

            Version appversion = new Version(1, 0, 1, 0);
            Version mainversion = new Version(1, 0, 2, 0);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void VersionTest_MainBumpRev()
        {

            Version appversion = new Version(1, 0, 1, 1);
            Version mainversion = new Version(1, 0, 1, 2);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void VersionTest_AppBumpBuild()
        {

            Version appversion = new Version(1, 0, 2, 1);
            Version mainversion = new Version(1, 0, 1, 1);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsFalse(result);

        }

        [TestMethod]
        public void VersionTest_AppBumpRev()
        {

            Version appversion = new Version(1, 0, 1, 2);
            Version mainversion = new Version(1, 0, 1, 1);

            var vc = new VersionChecker();

            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(path + "\\" + library)).WillReturn(appversion);
            Isolate.WhenCalled(() => AssemblyAbstraction.GetLibraryVerison(mainpath + "\\" + library)).WillReturn(mainversion);

            bool result = vc.CheckLibraryCompatibility(library);

            Assert.IsFalse(result);

        }


    }
}
