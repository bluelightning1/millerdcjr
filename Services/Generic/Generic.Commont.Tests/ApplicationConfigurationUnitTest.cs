using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic‎.Common‎.Configuration;
using Generic‎.Common‎.Extenders;

namespace Generic‎.Common‎t.Tests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationUnitTest
    /// </summary>
    [TestClass]
    public class ApplicationConfigurationUnitTest
    {

        public ApplicationConfigurationUnitTest()
        {
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
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
        #endregion


        [TestMethod]
        public void GetEnableLoggingTestMethod()
        {
            Assert.IsInstanceOfType(ApplicationConfiguration.GetEnableLogging(), typeof(bool));
        }

        [TestMethod]
        public void GetSchemaConnectionTestMethod()
        {
            string def = ApplicationConfiguration.GetSchemaDrivenConnection();
            Assert.IsNotNull(def);
            Assert.IsFalse(string.IsNullOrEmpty(def));
        }

        //[TestMethod]
        //public void GetApplicationNameTestMethod()
        //{
        //    string def = ApplicationConfiguration.GetApplicationName();
        //    Assert.IsNotNull(def);
        //    Assert.IsFalse(string.IsNullOrEmpty(def));
        //}

        [TestMethod]
        public void GetContinueTimeoutTestMethod()
        {
            var def = ApplicationConfiguration.GetContinueTimeout();
            Assert.IsTrue(def > 0);
        }

        //[TestMethod]
        //public void GetDateTimeFormatTestMethod()
        //{
        //    var def = ApplicationConfiguration.GetDateTimeFormat();
        //    Assert.IsFalse(string.IsNullOrEmpty(def));
        //}

        [TestMethod]
        public void GetDefaultConnectionTestMethod()
        {
            string def = ApplicationConfiguration.GetDefaultConnection();
            Assert.IsNotNull(def);
            Assert.IsFalse(string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetDefaultConnectionByAppSettingsValueByKeyTestMethod()
        {
            string def = ApplicationConfiguration.GetAppSettingsConnectionByKey("defaultConnection");
            Assert.IsNotNull(def);
            Assert.IsFalse(string.IsNullOrEmpty(def));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetAppSettingsConnectionByNoKeyTestMethod()
        {
            string def = ApplicationConfiguration.GetAppSettingsConnectionByKey("NoKey");
        }

        [TestMethod]
        public void GetAppSettingsByEmptyKeyTestMethod()
        {
            string def = ApplicationConfiguration.GetAppSettingsByKey("EmptyKey");
            Assert.IsTrue(string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetAppSettingsByNoKeyTestMethod()
        {
            string def = ApplicationConfiguration.GetAppSettingsByKey("NoKey");
            Assert.IsTrue(string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetEventLogSourceTestMethod()
        {
            string def = ApplicationConfiguration.GetEventLogSource();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetEventLogTestMethod()
        {
            string def = ApplicationConfiguration.GetEventLog();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetReadWriteTimeoutTestMethod()
        {
            int def = ApplicationConfiguration.GetReadWriteTimeout();
            Assert.IsTrue(def > 0);
        }

        [TestMethod]
        public void GetRequestAcceptTestMethod()
        {
            string def = ApplicationConfiguration.GetRequestAccept();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetRequestContentTypeTestMethod()
        {
            string def = ApplicationConfiguration.GetRequestContentType();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetRequestHeaderTestMethod()
        {
            string def = ApplicationConfiguration.GetRequestHeader();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetRequestMethodTestMethod()
        {
            string def = ApplicationConfiguration.GetRequestMethod();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }
        [TestMethod]
        public void GetRequestURLTestMethod()
        {
            string def = ApplicationConfiguration.GetRequestURL("");
            Assert.IsTrue(string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetSchemaDrivenConnectionTestMethod()
        {
            string def = ApplicationConfiguration.GetSchemaDrivenConnection();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetTimeoutTestMethod()
        {
            int def = ApplicationConfiguration.GetTimeout();
            Assert.IsTrue(def > 0);
        }

        //[TestMethod]
        //public void Get_DNSTestMethod()
        //{
        //    string def = ApplicationConfiguration.Get_DNS();
        //    Assert.IsTrue(!string.IsNullOrEmpty(def));
        //}

        [TestMethod]
        public void GetDefaultMySqlDateTimeFormatTestMethod()
        {
            string def = ApplicationConfiguration.GetDefaultMySqlDateTimeFormat();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetDateTimeFormatTestMethod()
        {
            string def = ApplicationConfiguration.GetDateTimeFormat();
            Assert.IsTrue(!string.IsNullOrEmpty(def));
        }

        [TestMethod]
        public void GetDefaultSplitterTestMethod()
        {
            var def = ApplicationConfiguration.GetDefaultSplitter();
            Assert.IsTrue(def != null );
            Assert.IsTrue(def.Length > 0);
        }


        [TestMethod]
        public void GetMessageLoggingResponsePathAndFileName()
        {
            var def = ApplicationConfiguration.GetMessageLoggingResponsePathAndFileName(DateTime.Now.ToFileTimeUtc().ToString());
            Assert.IsTrue(!string.IsNullOrEmpty(def));
            Assert.IsTrue(def.Length > 0);
        }


        [TestMethod]
        public void GetMessageLoggingRequestPathAndFileName()
        {
            var def = ApplicationConfiguration.GetMessageLoggingRequestPathAndFileName(DateTime.Now.ToFileTimeUtc().ToString());
            Assert.IsTrue(!string.IsNullOrEmpty(def));
            Assert.IsTrue(def.Length > 0);
        }
    }
}
