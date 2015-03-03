using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Extenders;
using Generic.Common.Configuration;

namespace Generic.Common.Tests
{
    [TestClass]
    public class DateTimeExtenderUnitTest
    {
        [TestMethod]
        public void GetDefaultMySqlDateTimeFormatTestMethod()
        {
            var s = DateTime.Now.ToMySqlDateString(ApplicationConfiguration.GetDefaultMySqlDateTimeFormat());
            Assert.IsTrue(!string.IsNullOrEmpty(s));
        }

        [TestMethod]
        public void GetDateTimeFormatTestMethod()
        {
            var s = DateTime.Now.ToMySqlDateString(ApplicationConfiguration.GetDateTimeFormat());
            Assert.IsTrue(!string.IsNullOrEmpty(s));
        }

        [TestMethod]
        public void GetDefaultMySqlDateTimeFormatEmptyTestMethod()
        {
            DateTime dt = new DateTime();
            var s = dt.ToMySqlDateString(ApplicationConfiguration.GetDefaultMySqlDateTimeFormat());
            Assert.IsTrue(string.IsNullOrEmpty(s));
        }

        [TestMethod]
        public void GetDateTimeFormatEmptyTestMethod()
        {
            DateTime dt = new DateTime();
            var s = dt.ToMySqlDateString(ApplicationConfiguration.GetDateTimeFormat());
            Assert.IsTrue(string.IsNullOrEmpty(s));
        }
    }
}
