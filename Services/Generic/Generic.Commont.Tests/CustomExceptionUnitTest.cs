using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Exceptions;
using Generic.Common.Extenders;
using Generic.Common.Configuration;

namespace Generic.Common.Tests
{
    [TestClass]
    public class CustomExceptionUnitTest
    {
        [TestMethod]
        public void InitTestMethod1()
        {
            DateTime dt;

            CustomException ex = new CustomException();
            Assert.IsTrue(string.IsNullOrEmpty(ex.Message));
            Assert.IsTrue(string.IsNullOrEmpty(ex.Source));
            Assert.IsTrue(string.IsNullOrEmpty(ex.StackTrace));
            Assert.IsTrue(DateTime.TryParse(ex.TimeStamp.ToString(), out dt));

        }

        [TestMethod]
        public void ExceptionTestMethod1()
        {
            DateTime dt;
            Exception ex = new Exception("Testing the application");

            CustomException cex = new CustomException();
            Assert.IsTrue(string.IsNullOrEmpty(cex.Message));
            Assert.IsTrue(string.IsNullOrEmpty(cex.Source));
            Assert.IsTrue(string.IsNullOrEmpty(cex.StackTrace));
            Assert.IsTrue(DateTime.TryParse(cex.TimeStamp.ToString(), out dt));
        }

        [TestMethod]
        public void ExceptionToStringTestMethod1()
        {
            var t = "Testing the application";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var c = cex.ToString();
            Assert.IsTrue(!string.IsNullOrEmpty(c));
            Assert.IsTrue(c.Equals(t));
        }

        [TestMethod]
        public void LogEWriteLocationDatabaseTestMethod1()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, Enums.EWriteLocation.Database));
        }

        [TestMethod]
        public void LogEWriteLocationEventViewerTestMethod1()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, Enums.EWriteLocation.EventViewer));
        }

        [TestMethod]
        public void LogEWriteLocationFileTestMethod1()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, Enums.EWriteLocation.File));
        }

        [TestMethod]
        public void LogEWriteLocationUnknownTestMethod1()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, Enums.EWriteLocation.Unknown));
        }

        [TestMethod]
        public void LogEWriteLocationUnknownTestMethod2Parms()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, @"\logs\", "testingUknown.txt"));
        }

        [TestMethod]
        public void LogEWriteLocationFileTestMethod2Parms()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, @"\logs\", "testingFile.txt"));
        }
       
        [TestMethod]
        public void LogEWriteLocationFileFalseTestMethod2Parms()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            Assert.IsFalse(cex.Log(false, @"\logs\", "testingFile.txt"));
        }

        [TestMethod]
        public void LogEWriteLocationUnknownTestMethod1Parms()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, @"\logs\testingUknown.txt"));
        }

        [TestMethod]
        public void LogEWriteLocationFileTestMethod1Parms()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            var b = ApplicationConfiguration.GetEnableLogging();
            Assert.IsTrue(cex.Log(b, @"\logs\testingFile.txt"));
        }

        [TestMethod]
        public void LogEWriteLocationFileFalseTestMethod1Parms()
        {
            var t = "Testing the application logging";
            Exception ex = new Exception(t);
            CustomException cex = new CustomException(ex);
            Assert.IsFalse(cex.Log(false, @"\logs\testingFile.txt"));
        }
    }
}
