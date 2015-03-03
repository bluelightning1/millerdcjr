using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generic.Common.Tests
{
    [TestClass]
    public class SerializerUnitTest
    {
        [TestMethod]
        public void SerializerTestMethod()
        {
            Person p = new Person();
            p.name = "Dan";
            Assert.IsTrue(Serializer.XmlSerializeToFile<Person>(@"\logs\person.log", p));
            p = null;
        }

        [TestMethod]
        public void SerializerToStringTestMethod()
        {
            Person p = new Person();
            p.name = "Dan";
            var s = Serializer.XmlSerializeToString<Person>(p);
            Assert.IsFalse(string.IsNullOrEmpty(s));
            p = null;
        }

        [TestMethod]
        public void SerializerFromStringTestMethod()
        {
            Person p = new Person();
            p.name = "Dan";
            var s = Serializer.XmlSerializeToString<Person>(p);

            var x = Serializer.XmlDeserializeFromString<Person>(s);
            Assert.IsNotNull(x);

            s = null;
            x = null;
            p = null;
        }


        public class Person
        {
            public string name { get; set; }
        }
    }
}
