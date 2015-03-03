using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Enums;
using Generic.Common.Extenders;

namespace Generic.Common.Tests
{
    [TestClass]
    public class EEnteredTypeEnumExtenderUnitTest
    {
        [TestMethod]
        public void GetDatabaseCodeTestMethod()
        {
            var des = EEnteredType.Device_Entered.GetDatabaseCode();
            Assert.IsTrue(!string.IsNullOrEmpty(des));
            Assert.AreEqual("Y", des);
        }

        [TestMethod]
        public void GetVUIDCodeTestMethod()
        {
            var des = EEnteredType.Device_Entered.GetVUIDCode();
            Assert.IsTrue(!string.IsNullOrEmpty(des));
            Assert.AreEqual("4500983", des);
        }

        [TestMethod]
        public void GetNameTestMethod()
        {
            var des = EEnteredType.Device_Entered.GetName();
            Assert.IsTrue(!string.IsNullOrEmpty(des));
            Assert.AreEqual("Device Entered", des);
        }

        [TestMethod]
        public void GetDescriptionTestMethod()
        {
            var des =  EEnteredType.Device_Entered.GetDescription();
            Assert.IsTrue(string.IsNullOrEmpty(des));
        }
    }
}
