using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Data;
using Generic‎.Common‎.Enums;
using Generic.Common.DataAccessLayer;

namespace Generic‎.Common‎t.Tests
{
    /// <summary>
    /// Summary description for SqlWrapperUnitTest
    /// </summary>
    [TestClass]
    public class SqlWrapperUnitTest
    {
        public SqlWrapperUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
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

        #region "mysql tests commented out."
        //[TestMethod]
        //[ExpectedException(typeof(InvalidOperationException))]
        //public void SqlWrapperReadInvalidQueryTestMethod()
        //{
        //    SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //    var com = new MySqlCommand("");
        //    wrapper.Read(com);
        //}

        //[TestMethod]
        //[ExpectedException(typeof(MySqlException))]
        //public void SqlWrapperReadInvalidParametersTestMethod()
        //{
        //    SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //    var com = new MySqlCommand("CALL ``.`getErrorIdentifiersByIdentifier`();");
        //    MySqlDataReader reader = (MySqlDataReader) wrapper.Read(com);
        //}

        //[TestMethod]
        //public void SqlWrapperInvalidParametersTestMethod()
        //{
        //    SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //    var com = new MySqlCommand(".getErrorIdentifiersByIdentifier");
        //    com.CommandType = CommandType.StoredProcedure;

        //    MySqlParameter parm = new MySqlParameter("?parmidentifier", 100);
        //    parm.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm);
        //    MySqlDataReader reader = (MySqlDataReader)wrapper.Read(com);
        //    Assert.IsNotNull(reader);
        //    wrapper.Dispose();
        //    wrapper = null;
        //    com.Dispose();
        //    com = null;
        //    reader.Dispose();
        //    reader = null;
        //}

        //[TestMethod]
        //public void SqlWrapperCreateTestMethod()
        //{
        //    SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //    var com = new MySqlCommand(".createErrorIdentifiersByIdentifier");
        //    com.CommandType = CommandType.StoredProcedure;

        //    MySqlParameter parm = new MySqlParameter("?parmidentifier", 999);
        //    parm.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm);
        //    MySqlParameter parm1 = new MySqlParameter("?parmText", "Unit Test");
        //    parm1.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm1);

        //    MySqlParameter parm2 = new MySqlParameter("?parmMessage", "this is invalid don't use this it is part of the Unit Test");
        //    parm2.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm2);
        //    int x = (int)wrapper.Create(com);
        //    Assert.IsTrue(x ==1);
        //    wrapper.Dispose();
        //    wrapper = null;
        //    com.Dispose();
        //    com = null;
        //    parm = null;
        //    parm1 = null;
        //    parm2 = null;
        //}

        //[TestMethod]
        //public void SqlWrapperUpdateTestMethod()
        //{
        //    SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //    var com = new MySqlCommand(".updateErrorIdentifiersByIdentifier");
        //    com.CommandType = CommandType.StoredProcedure;

        //    MySqlParameter parm = new MySqlParameter("?parmidentifier", 999);
        //    parm.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm);

        //    MySqlParameter parm1 = new MySqlParameter("?parmText", "Unit Test1");
        //    parm1.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm1);

        //    MySqlParameter parm2 = new MySqlParameter("?parmMessage", "this is invalid don't use this it is part of the Unit Test1");
        //    parm2.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm2);

        //    int x = wrapper.Update(com);
        //    Assert.IsTrue(x != 0 );
        //    wrapper.Dispose();
        //    wrapper = null;
        //    com.Dispose();
        //    com = null;
        //    parm = null;
        //    parm1 = null;
        //    parm2 = null;
        //}

        //[TestMethod]
        //public void SqlWrapperDeleteTestMethod()
        //{
        //    SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //    var com = new MySqlCommand(".deleteErrorIdentifiersByIdentifier");
        //    com.CommandType = CommandType.StoredProcedure;

        //    MySqlParameter parm = new MySqlParameter("?parmidentifier", 999);
        //    parm.Direction = ParameterDirection.Input;
        //    com.Parameters.Add(parm);

        //    int x = wrapper.Delete(com);
        //    Assert.IsTrue(x == 1);
        //    wrapper.Dispose();
        //    wrapper = null;
        //    com.Dispose();
        //    com = null;
        //    parm = null;
        //}

        #endregion " end mysql commands"
    }
}
