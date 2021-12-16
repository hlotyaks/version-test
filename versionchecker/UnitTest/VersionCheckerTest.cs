using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionChecker;

namespace VersionChecker.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            VersionChecker vc = new VersionChecker();

            vc.CheckLibraryCompatibility("");

        }
    }
}
