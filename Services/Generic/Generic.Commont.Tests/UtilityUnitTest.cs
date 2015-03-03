using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic‎.Common‎;
using System.IO;

namespace Generic‎.Common‎t.Tests
{
    [TestClass]
    public class UtilityUnitTest
    {
        [TestMethod]
        public void CreateDirectoryWithSubdirectoryTestMethod()
        {
            var dir = @"c:\unittest\dir\";
            Utilities.CreatDirectory(dir);
            Assert.IsTrue(Directory.Exists(dir));
            Directory.Delete(dir, true);
        }

        [TestMethod]
        public void CreateDirectoryFileTestMethod()
        {
            var dir = @"c:\unittest\dire.txt";
            Utilities.CreatDirectory(dir);
            var direct =dir.Substring(0, dir.LastIndexOf("\\"));
            DirectoryInfo info = new DirectoryInfo(direct);
            Assert.IsTrue(info.Exists);
            Directory.Delete(direct, true);
        }
    }
}
