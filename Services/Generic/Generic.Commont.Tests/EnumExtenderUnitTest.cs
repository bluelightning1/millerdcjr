using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic‎.Common‎.Extenders;
using System.Collections.Generic;
using Generic‎.Common‎.Enums;
using System.Linq;
namespace Generic‎.Common‎t.Tests
{
    [TestClass]
    public class EnumExtenderUnitTest
    {
        [TestMethod]
        public void GetEnumValuesTestMethod()
        {
            IEnumerable<EErrorIdentifier> errors = EErrorIdentifier.CannotLocatePatientWithICN.GetEnumValues<EErrorIdentifier>();
            Assert.IsTrue(errors.Count() > 0);
        }

        [TestMethod]
        public void GetDescriptionTestMethod()
        {
            string errors = EErrorIdentifier.CannotLocatePatientWithICN.GetDescription();
            Assert.IsFalse(string.IsNullOrEmpty(errors));
        }

        [TestMethod]
        public void GetEnumDescriptionsTestMethod()
        {
            IEnumerable<string> errors = EErrorIdentifier.CannotLocatePatientWithICN.GetEnumDescriptions<EErrorIdentifier>();
            Assert.IsTrue(errors.Count() > 0);
        }

        [TestMethod]
        public void GetAttributeDescriptionTestMethod()
        {
            var err = EAcknowledgementCode.Accepted.GetAttributeDescription();
            Assert.IsTrue(!string.IsNullOrEmpty(err));
        }
        [TestMethod]
        public void GetEnumValueTestMethod()
        {
            var err = EErrorIdentifier.CannotLocatePatientWithICN.GetEnumValue<EErrorIdentifier>("CannotLocatePatientWithICN");
            Assert.IsTrue(!string.IsNullOrEmpty(err.ToString()));
        }
    }
}
