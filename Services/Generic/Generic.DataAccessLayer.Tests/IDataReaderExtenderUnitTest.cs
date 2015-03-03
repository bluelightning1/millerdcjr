using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using MySql.Data.MySqlClient;
using Generic‎.Common‎.Extenders;
using Generic‎.Common‎.Configuration;
using Generic‎.Common‎.Exceptions;
using Generic‎.Common‎.Enums;
using System.Reflection;
using Generic.Common.DataAccessLayer;

namespace Generic‎.DataAccessLayer.Tests
{
    [TestClass]
    public class IDataReaderExtenderUnitTest
    {
        //private string schema = "nxdb_mirth";
        //private SqlWrapper Helper { get; set; }
        //private IDataReader Reader { get; set; }
        //public string patientGuid = "0224233997";///to insert a record change the last digit

        //public Datatypes Read()
        //{
        //    var str = string.Format("Class: {0}, Method: {1}", MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name);
        //    Datatypes rv = new Datatypes();
        //    try
        //    {
        //        Helper = new SqlWrapper(EConnection.Default);
        //        var command =  new MySqlCommand(string.Format("`{0}`.`{1}`", schema, "nxs_get_patients"));
        //        command.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter param = new MySqlParameter("?parmPatientKey", patientGuid);
        //        param.Direction = ParameterDirection.Input;

        //        command.Parameters.Add(param);

        //        Reader = Helper.Read(command);

        //        while (Reader.Read())
        //        {
        //            rv.dob = Reader.GetDateTime("DOB");
        //            break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomException cex = new CustomException(str, ex);
        //        cex.Log(EWriteLocation.EventViewer);
        //        cex = null;
        //        throw;
        //    }

        //    finally { }
        //    return rv;
        //}

        //[TestMethod]
        //public void GetDateTimeTestMethod()
        //{
        //    Datatypes dt = Read();
        //    DateTime v;

        //    Assert.IsTrue(dt.dob != DateTime.MaxValue && dt.dob != DateTime.MinValue);

        //    Assert.IsTrue(DateTime.TryParse(dt.dob.ToString(), out v));
        //    dt = null;
        //    Dispose();
        //}

        private void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool b)
        {
            if (b)
            {
                //if (Reader != null)
                //{
                //    Reader.Close();
                //    Reader.Dispose();
                //    Reader = null;
                //}
                //if (this.Helper != null)
                //{
                //    Helper.Dispose();
                //    Helper = null;
                //}
            }
        }
    }

    public class Datatypes
    {
        public DateTime dob { get; set; }
    }
}
