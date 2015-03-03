using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Enums;

namespace Generic.Common.Tests
{
    [TestClass]
    public class EnteredTypeAttributeUnitTest
    {
        string desc = "description";
        string vuidCode = "vuidcode";
        string databaseCode = "databaseCode";
        string name = "name";

        [TestMethod]
        public void EnteredTypeAttributeTestMethod()
        {
            EnteredTypeAttribute ea = new EnteredTypeAttribute();
            Assert.IsTrue(string.IsNullOrEmpty(ea.DatabaseCode));
            Assert.IsTrue(string.IsNullOrEmpty(ea.Description));
            Assert.IsTrue(string.IsNullOrEmpty(ea.Name));
            Assert.IsTrue(string.IsNullOrEmpty(ea.VUIDCode));
        }

        [TestMethod]
        public void EnteredTypeAttributeTest3parmsMethod()
        {
            EnteredTypeAttribute ea = new EnteredTypeAttribute(vuidCode, databaseCode, name);
            Assert.AreEqual(databaseCode, ea.DatabaseCode);
            Assert.AreEqual(name, ea.Name);
            Assert.AreEqual(vuidCode, ea.VUIDCode);
            Assert.AreEqual("", ea.Description);
        }

        [TestMethod]
        public void EnteredTypeAttribute4parmsTestMethod()
        {
            EnteredTypeAttribute ea = new EnteredTypeAttribute(desc, vuidCode, databaseCode, name);
            Assert.AreEqual(databaseCode, ea.DatabaseCode);
            Assert.AreEqual(desc, ea.Description);
            Assert.AreEqual(name, ea.Name);
            Assert.AreEqual(vuidCode, ea.VUIDCode);
        }
    }
}
