using Generic.Common.DataAccessLayer;
using Generic.Common.Enums;
using Generic.Common.Extenders;
using Generic.Common.Interfaces;
using Millerdcjr.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Millerdcjr.DAL
{
    public class CountryBOList : List<CountryBO>
    {
        ////Add CountryBO objects to the instance of CountryBOList to Create them in the Database.
        //public CountryBO Create(CountryBO country)
        //{
        //    Message rv = null;

        //    if (country != null)
        //    {
        //        var list = new List<SqlCommand>();
        //        var commandText = "CountryCreate";

        //        List<SqlParameter> collection = BuildCreateCollection(country);
        //        var command = new SqlCommand
        //        {
        //            CommandText = commandText,
        //            CommandType = System.Data.CommandType.StoredProcedure,
        //        };

        //        command.Parameters.AddRange(collection.ToArray());

        //        SqlWrapper wrapper = new SqlWrapper(EConnection.Default);
        //        wrapper.Create(command);
        //        rv.Key = GetKey(command, "CountryID");

        //        wrapper.Dispose();
        //        wrapper = null;
        //    }
        //    return rv;
        //}

        //private Guid GetKey(SqlCommand command, string keyName)
        //{
        //    throw new NotImplementedException();

        //    Guid rv = new Guid();

        //    var parms = command.Parameters["@" + keyName];
        //    if (parms != null)
        //    {
        //        if (parms.Value != null)
        //        {
        //            // TODO: Guid.TryParse(parms.Value.ToString(), out rv);
        //        }
        //    }
        //    return rv;
        //}

        private List<SqlParameter> BuildParameterCollection(ParameterDirection direction, Guid? countryID = null, string name = null, string iso2 = null, string iso3 = null)
        {
            var list = new List<SqlParameter>();
            SqlParameter parm = null;

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.UniqueIdentifier;
            parm.Direction = direction;
            parm.ParameterName = "@countryID";
            parm.Value = countryID == null ? (object)DBNull.Value : countryID;
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Size = 2;
            parm.Value = iso2 == null ? DBNull.Value.ToString() : iso2;
            parm.Direction = direction;
            parm.ParameterName = "@isoCode2";
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Direction = direction;
            parm.Size = 3;
            parm.Value = iso3 == null ? DBNull.Value.ToString() : iso3;
            parm.ParameterName = "@isoCode3";
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Direction = direction;
            parm.Size = 50;
            parm.Value = name == null ? DBNull.Value.ToString() : name;
            parm.ParameterName = "@name";
            list.Add(parm);

            return list;
        }

        private List<SqlParameter> BuildReadParameterCollection(ParameterDirection direction, Guid? countryID = null, string name = null, string iso2 = null, string iso3 = null)
        {
            var list = new List<SqlParameter>();
            SqlParameter parm = null;

            parm = new SqlParameter();
            if (countryID != null)
            {
                parm.SqlDbType = SqlDbType.UniqueIdentifier;
                parm.Direction = direction;
                parm.ParameterName = "@countryID";
                parm.Value = countryID == null ? (object)DBNull.Value : countryID;
                list.Add(parm);
            }

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Size = 2;
            parm.Value = iso2 == null ? DBNull.Value.ToString() : iso2;
            parm.Direction = direction;
            parm.ParameterName = "@isoCode2";
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Direction = direction;
            parm.Size = 3;
            parm.Value = iso3 == null ? DBNull.Value.ToString() : iso3;
            parm.ParameterName = "@isoCode3";
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Direction = direction;
            parm.Size = 50;
            parm.Value = name == null ? DBNull.Value.ToString() : name;
            parm.ParameterName = "@name";
            list.Add(parm);

            return list;
        }

        public CountryBO Create(string name, string isoCode2, string isoCode3, EWriteLocation location)
        {
            SqlCommand sqlCommand = new SqlCommand();
            CountryBO rv = null;
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(isoCode2) || string.IsNullOrEmpty(isoCode3))
                {
                    throw new NullReferenceException("The Country name, iso 2 and 3 digit code must not be null or empty");
                }
                else
                {
                    sqlCommand.CommandText = "[dbo].[CountryCreate]";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    parms = BuildParameterCollection(ParameterDirection.InputOutput, null, name, isoCode2, isoCode3);
                    sqlCommand.Parameters.AddRange(parms.ToArray());
                    helper = new MySqlConnectionHelper(EConnection.Default);

                    var obj = helper.Create(sqlCommand);
                    if (obj != null)
                    {
                        var rvx = parms.Where(x => x.ParameterName.Equals("@countryID", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        var dname = parms.Where(x => x.ParameterName.Equals("@name", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        var code2 = parms.Where(x => x.ParameterName.Equals("@isoCode2", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        var code3 = parms.Where(x => x.ParameterName.Equals("@isoCode3", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                        if (rvx == null)
                        {

                        }
                        else
                        {
                            rv = new CountryBO
                            {
                                ID = rvx.Value.GetGuid(),
                                Name = dname.Value.ToString(),
                                ISOCode2 = code2.Value.ToString(),
                                ISOCode3 = code3.Value.ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write(Assembly.GetCallingAssembly().FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, ex, location.GetDescription(), null, null);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (parms != null)
                {
                    parms.Clear();
                    parms = null;
                }
                if (helper != null)
                {
                    helper.Dispose();
                    helper = null;
                }
            }
            return rv;
        }

        public void Read(CountryBOCriteria criteria)
        {
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parms = null;
            SqlWrapper wrapper = new SqlWrapper(EConnection.Default);

            try
            {
                if (criteria != null)
                {
                    if (!string.IsNullOrEmpty(criteria.PartialCountry) && criteria.LoadOption == ELookup.ByPartialName)
                    {
                        sqlCommand.CommandText = "[dbo].[CountryRead]";
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(
                            BuildReadParameterCollection(ParameterDirection.Input, null, criteria.PartialCountry, criteria.PartialCountry, criteria.PartialCountry).ToArray());

                        var dr = wrapper.Read(sqlCommand);
                        if (dr != null)
                        {
                            SqlDataReader reader = (SqlDataReader)dr;
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    this.Add(new CountryBO
                                    {
                                        ID = reader.GetGuid("ID"),
                                        ISOCode2 = reader.GetString("ISOCode2", null),
                                        ISOCode3 = reader.GetString("ISOCode3", null),
                                        Name = reader.GetString("Name", null)
                                    });
                                }
                            }
                        }
                        if (dr != null)
                        {
                            dr.Dispose();
                            dr = null;
                        }
                    }
                    else
                    {
                        throw new NullReferenceException("Partial Country property must not be null or empty");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write(Assembly.GetCallingAssembly().FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, ex, criteria.WriteLocation.GetDescription(), null, null);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (parms != null)
                {
                    parms.Clear();
                    parms = null;
                }
                if (wrapper != null)
                {
                    wrapper.Dispose();
                    wrapper = null;
                }
            }
        }

        public CountryBO Update(Guid countryID, string nameParm, string isoCode2, string isoCode3, EWriteLocation location)
        {
            CountryBO rv = null;
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                sqlCommand.CommandText = "[dbo].[CountryUpdate]";
                parms = BuildParameterCollection(ParameterDirection.InputOutput, countryID, nameParm, isoCode2, isoCode3);
                sqlCommand.Parameters.AddRange(parms.ToArray());
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                helper = new MySqlConnectionHelper(EConnection.Default);

                var obj = helper.Update(sqlCommand);
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }

                var ctryID = parms.Where(x => x.ParameterName.Equals("@countryID", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var name = parms.Where(x => x.ParameterName.Equals("@name", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var code2 = parms.Where(x => x.ParameterName.Equals("@isocode2", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var code3 = parms.Where(x => x.ParameterName.Equals("@isocode3", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (ctryID == null && name == null && code2 == null && code3 == null)
                {

                }
                else
                {
                    rv = new CountryBO
                    {
                        ID = ctryID.Value.GetGuid(),
                        Name = name.Value.ToString(),
                        ISOCode2 = code2.Value.ToString(),
                        ISOCode3 = code3.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write(Assembly.GetCallingAssembly().FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, ex, location.GetDescription(), null, null);
            }
            finally
            {

                if (parms != null)
                {
                    parms.Clear();
                    parms = null;
                }
                if (helper != null)
                {
                    helper.Dispose();
                    helper = null;
                }
            }

            return rv;
        }

        public CountryBO Delete(Guid countryID, EWriteLocation location)
        {
            CountryBO rv = null;
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                sqlCommand.CommandText = "[dbo].[CountryDelete]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                parms = BuildParameterCollection(ParameterDirection.InputOutput, countryID);
                sqlCommand.Parameters.AddRange(parms.ToArray());
                helper = new MySqlConnectionHelper(EConnection.Default);

                var obj = helper.Delete(sqlCommand);
                var ctryID = parms.Where(x => x.ParameterName.Equals("@countryID", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var name = parms.Where(x => x.ParameterName.Equals("@name", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var isocode2 = parms.Where(x => x.ParameterName.Equals("@isocode2", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                var isocode3 = parms.Where(x => x.ParameterName.Equals("@isocode3", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (ctryID == null && name == null && isocode2 == null && isocode3 == null)
                {

                }
                else
                {
                    rv = new CountryBO
                    {
                        ID = ctryID.Value.GetGuid(),
                        Name = name.Value.ToString(),
                        ISOCode2 = isocode2.Value.ToString(),
                        ISOCode3 = isocode3.Value.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                LogHandler.Write(Assembly.GetCallingAssembly().FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, ex, location.GetDescription(), null, null);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (parms != null)
                {
                    parms.Clear();
                    parms = null;
                }
                if (helper != null)
                {
                    helper.Dispose();
                    helper = null;
                }
            }

            return rv;
        }
    }
}
