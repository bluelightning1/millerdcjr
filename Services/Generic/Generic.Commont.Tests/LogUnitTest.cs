using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic‎.Common‎.Log;
using Generic‎.Common‎.Configuration;
using System.IO;
using Generic‎.Common‎.Exceptions;

namespace Generic‎.Common‎t.Tests
{
    [TestClass]
    public class LogUnitTest
    {
        string pathAndFileName = string.Empty;
        string path = string.Empty;
        string val = @"\SomeTestFile.xml";
        string dir = @"\NewDirectoryCreate";
        string staticdir = @"\logs";

        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        [TestMethod]
        public void LogTestMethod()
        {
            Assert.IsTrue(Log.Write(new CustomException("LogException 1"), staticdir));
        }

        //[TestMethod]
        //public void LogInnerExceptionTestMethod()
        //{
        //    var ex = new Exception("InnerException");
        //    Assert.IsTrue(Log.Write(new CustomException("LogException InnerException 1", ex), pathAndFileName));
        //    ex = null;
        //}

        //[TestMethod]
        //public void LogTwoInnerExceptionTestMethod()
        //{
        //    var exi = new Exception("second InnerException");
        //    var ex = new Exception("first InnerException", exi);

        //    Assert.IsTrue(Log.Write(new CustomException("LogException Two InnerExceptions", ex), pathAndFileName));
        //    ex = null;
        //    exi = null;
        //}

        //[TestMethod]
        //public void LogThreeInnerExceptionTestMethod()
        //{
        //    var exi3 = new Exception("Third InnerException");
        //    var exi = new Exception("second InnerException", exi3);
        //    var ex = new Exception("first InnerException", exi);

        //    Assert.IsTrue(Log.Write(new CustomException("LogException Two InnerExceptions", ex), pathAndFileName));
        //    ex = null;
        //    exi = null;
        //    exi3 = null;
        //}

        [TestMethod]
        public void LogFileNameAndPathTestMethod()
        {
            pathAndFileName = dir + val;
            var file = pathAndFileName.Remove(0, pathAndFileName.LastIndexOf("\\"));
            Assert.IsTrue(Log.Write(new CustomException("LogException Name And Paths"), dir, val));
        }

        [TestMethod]
        public void LogClearTestMethod()
        {
            Assert.IsTrue(Log.Clear(staticdir, 5));
        }

        [TestMethod]
        public void LogClearNullTestMethod()
        {
            Assert.IsFalse(Log.Clear(null, 5));
        }

        [TestMethod]
        public void LogClearDoesNotExistTestMethod()
        {
            Assert.IsFalse(Log.Clear(@"\doesNotExist", 5));
        }

        [TestMethod]
        public void LogNewDirectoryCreateTestMethod()
        {
            Assert.IsTrue(Log.Write(new CustomException(dir + val), dir + val));
            var dirBool = Directory.Exists(dir);
            Assert.IsTrue(dirBool);

            if (dirBool)
                Directory.Delete(dir, true);

            var dirB = Directory.Exists(dir);
            Assert.IsFalse(dirB);
        }

        [TestMethod]
        public void LogNewSeparateDirectoryCreateTestMethod()
        {
            Assert.IsTrue(Log.Write(new CustomException(dir + val), dir, val));

            Assert.IsTrue(Directory.Exists(dir));

            if (Directory.Exists(dir))
                Directory.Delete(dir, true);

            Assert.IsFalse(Directory.Exists(dir));
        }

        [TestMethod]
        public void LogUnitTestClearCreateAndDeleteFilesTestMethod()
        {
            Assert.IsTrue(Log.Write(new CustomException(dir + val), dir, val));

            Log.UnitTestClear(dir, 0);

            Assert.IsTrue(Directory.Exists(dir));

            if (Directory.Exists(dir))
                Directory.Delete(dir, true);

            Assert.IsFalse(Directory.Exists(dir));
        }

        [TestMethod]
        public void LogClearCreateAndDeleteFilesTestMethod()
        {
            Assert.IsTrue(Log.Write(new CustomException(dir + val), dir, val));

            Log.Clear(dir, 0, 0);

            Assert.IsTrue(Directory.Exists(dir));

            if (Directory.Exists(dir))
                Directory.Delete(dir, true);

            Assert.IsFalse(Directory.Exists(dir));
        }

    }
}
