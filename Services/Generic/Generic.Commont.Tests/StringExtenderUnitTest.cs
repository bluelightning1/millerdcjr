using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Extenders;
using System.Collections.Generic;

namespace Generic.Common.Tests
{
    [TestClass]
    public class StringExtenderUnitTest
    {
        string stringWithReplacementValues = "<something><string></string></something>";
        string stringToReplace = "something";
        List<string> stringsToList = new List<string> { "a", "b", "c", "d", "e" };
        string stringToListExpected = "a,b,c,d,e";
        string stringToWhereExpected = "'a','b','c','d','e'";
        string dateStringTest = "20141110";

        [TestMethod]
        public void ReplaceElementsWithDefaultTestMethod()
        {
            var s = stringWithReplacementValues.ReplaceElementsWithDefault(stringToReplace);
            Assert.IsTrue(!s.Contains(stringToReplace));
        }

        [TestMethod]
        public void ToMySqlDateStringFromDateTestMethod()
        {
            var now = DateTime.Now.ToString();
            var myNow = now.ToMySqlDateString();
            Assert.IsTrue(!string.IsNullOrEmpty(myNow));
        }

        [TestMethod]
        public void ToMySqlDateStringWithDateStringTestMethod()
        {
            var myNow = dateStringTest.ToMySqlDateString();
            Assert.IsTrue(!string.IsNullOrEmpty(myNow));
        }

        [TestMethod]
        public void ToStringTestMethod()
        {
            var myNow = stringsToList.ToString(",");

            Assert.AreEqual(stringToListExpected, myNow);
        }

        [TestMethod]
        public void ToWhereClauseStringTestMethod()
        {
            var myNow = stringsToList.ToWhereClauseString(",", "'");

            Assert.AreEqual(stringToWhereExpected, myNow);
        }
    }
}
