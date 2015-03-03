using Generic.Common.DataAccessLayer;
using Generic.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Generic.Common.Extenders;
using System.Data;

namespace Millerdcjr.DAL
{
    public class StateBOList : List<StateBO>
    {
        private StateBOCriteria Criteria { get; set; }

        public StateBOList()
        {
            this.Criteria = null;
        }

        public void Read(StateBOCriteria criteria)
        {
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                if (criteria != null)
                {
                    if (string.IsNullOrEmpty(criteria.PartialState) && criteria.Lookup == ELookup.ByPartialName)
                    {
                        throw new NullReferenceException("Partial Country property must not be null or empty");
                    }
                    else if ((criteria.CountryId == new Guid() || criteria.StateId == new Guid()) && criteria.Lookup == ELookup.ByGuid)
                    {
                        throw new NullReferenceException("CountryId  and StateId must not be null or empty");
                    }

                    sqlCommand.CommandText = "[dbo].[CountryZonesRead]";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    parms = BuildCreateCollection(criteria.Operation, ParameterDirection.InputOutput, criteria.CountryId, criteria.StateId, criteria.PartialState, criteria.PartialState);
                    sqlCommand.Parameters.AddRange(parms.ToArray());

                    helper = new MySqlConnectionHelper(EConnection.Default);
                    var dr = helper.Read(sqlCommand);
                    if (dr != null)
                    {
                        SqlDataReader reader = (SqlDataReader)dr;
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                this.Add(new StateBO
                                {
                                    ID = reader.GetGuid("ID"),
                                    IsoCode2 = reader.GetString("code", null),
                                    CountryID = reader.GetGuid("countryId"),
                                    Name = reader.GetString("Name", null)
                                });
                            }
                        }
                    }
                    dr.Dispose();
                    dr = null;

                }
            }
            catch (Exception ex)
            {

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
        }

        public StateBO Create(Guid countryId, string name, string isoCode2)
        {
            SqlCommand sqlCommand = new SqlCommand();
            StateBO rv = null;
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(isoCode2))
                {
                    throw new NullReferenceException("The Country name, iso 2 and 3 digit code must not be null or empty");
                }
                else
                {
                    sqlCommand.CommandText = "[dbo].[CountryZonesCreate]";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    parms = BuildCreateCollection(EOperation.Create, ParameterDirection.InputOutput, countryId, null, name, isoCode2);
                    sqlCommand.Parameters.AddRange(parms.ToArray());
                    helper = new MySqlConnectionHelper(EConnection.Default);

                    var obj = helper.Create(sqlCommand);
                    if (obj != null)
                    {
                        var rvx = parms.Where(x => x.ParameterName.Equals("@countryID", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        var state = parms.Where(x => x.ParameterName.Equals("@stateId", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        var dname = parms.Where(x => x.ParameterName.Equals("@name", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                        var code2 = parms.Where(x => x.ParameterName.Equals("@code", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                        if (rvx == null)
                        {

                        }
                        else
                        {
                            rv = new StateBO
                            {
                                ID = state.Value.GetGuid(),
                                CountryID = rvx.Value.GetGuid(),
                                Name = dname.Value.ToString(),
                                IsoCode2 = code2.Value.ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {

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


        public StateBO Delete(Guid countryId, Guid stateId, string stateName, string code)
        {

            StateBO rv = null;
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                sqlCommand.CommandText = "[dbo].[CountryZonesDelete]";
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                parms = BuildCreateCollection(EOperation.Delete, ParameterDirection.InputOutput, countryId, stateId, stateName, code);
                sqlCommand.Parameters.AddRange(parms.ToArray());
                helper = new MySqlConnectionHelper(EConnection.Default);

                var obj = helper.Delete(sqlCommand);
                if (obj > 0)
                {
                    var ctryID = parms.Where(x => x.ParameterName.Equals("@countryID", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    var state = parms.Where(x => x.ParameterName.Equals("@stateId", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    var name = parms.Where(x => x.ParameterName.Equals("@name", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    var isocode2 = parms.Where(x => x.ParameterName.Equals("@code", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    if (ctryID == null && name == null && isocode2 == null)
                    {

                    }
                    else
                    {
                        rv = new StateBO
                        {
                            ID = state.Value.GetGuid(),
                            CountryID = ctryID.Value.GetGuid(),
                            Name = name.Value.ToString(),
                            IsoCode2 = isocode2.Value.ToString(),
                        };
                    }
                }
            }
            catch (Exception ex)
            {

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

        public StateBO Update(Guid countryId, Guid stateID, string nameParm, string isoCode2)
        {
            StateBO rv = null;
            SqlCommand sqlCommand = new SqlCommand();
            List<SqlParameter> parms = null;
            MySqlConnectionHelper helper = null;

            try
            {
                sqlCommand.CommandText = "[dbo].[StateUpdate]";
                parms = BuildCreateCollection(EOperation.Update, ParameterDirection.InputOutput, countryId, stateID, nameParm, isoCode2);
                sqlCommand.Parameters.AddRange(parms.ToArray());
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                helper = new MySqlConnectionHelper(EConnection.Default);

                var obj = helper.Update(sqlCommand);
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }

                if (obj > 0)
                {
                    var ctryID = parms.Where(x => x.ParameterName.Equals("@countryID", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    var name = parms.Where(x => x.ParameterName.Equals("@name", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    var code2 = parms.Where(x => x.ParameterName.Equals("@isocode2", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                    if (ctryID == null && name == null && code2 == null)
                    {

                    }
                    else
                    {
                        rv = new StateBO
                        {
                            ID = ctryID.Value.GetGuid(),
                            Name = name.Value.ToString(),
                            IsoCode2 = code2.Value.ToString(),
                        };
                    }
                }
            }
            catch (Exception ex)
            {

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

        private List<SqlParameter> BuildCreateCollection(EOperation operation, ParameterDirection parameterDirection, Guid? countryId = null, Guid? stateID = null, string nameParm = null, string isoCode2 = null)
        {
            var list = new List<SqlParameter>();
            SqlParameter parm = null;

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.UniqueIdentifier;
            parm.Direction = parameterDirection;
            parm.ParameterName = "@stateId";
            parm.Value = stateID == null ? (object)DBNull.Value : stateID;
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.UniqueIdentifier;
            parm.Direction = parameterDirection;
            parm.ParameterName = "@countryId";
            parm.Value = countryId == null ? (object)DBNull.Value : countryId;
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Size = 2;
            parm.Value = isoCode2 == null ? DBNull.Value.ToString() : isoCode2;
            parm.Direction = parameterDirection;
            parm.ParameterName = "@code";
            list.Add(parm);

            parm = new SqlParameter();
            parm.SqlDbType = SqlDbType.NVarChar;
            parm.Direction = parameterDirection;
            parm.Size = 50;
            parm.Value = nameParm == null ? DBNull.Value.ToString() : nameParm;
            parm.ParameterName = "@name";
            list.Add(parm);

            return list;
        }

    }
}
