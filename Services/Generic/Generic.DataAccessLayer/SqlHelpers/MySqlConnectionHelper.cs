using Generic‎.Common‎.Configuration;
using Generic‎.Common‎.Enums;
using Generic‎.Common‎.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Generic‎.Common‎.DataAccessLayer
{
    public class MySqlConnectionHelper : ISqlHelper, IDisposable
    {

        public MySqlConnectionHelper(EConnection connectionType)
        {
            this.ConnectionType = connectionType;
        }

        private EConnection ConnectionType { get; set; }
        private SqlConnection SqlConnection { get; set; }
        private SqlDataReader SqlReader { get; set; }

        private MySqlConnection MySqlConnection { get; set; }
        private MySqlDataAdapter DataAdapter { get; set; }
        private MySqlDataReader Reader { get; set; }

        public object Create(IDbCommand mySqlCommand)
        {
            int x = -1;
            if (mySqlCommand.GetType().Equals(typeof(MySqlCommand)))
            {
                this.MySqlConnection = new MySqlConnection(GetConnection());
                if (mySqlCommand.Connection != null) { }
                else { mySqlCommand.Connection = this.MySqlConnection; }
                this.MySqlConnection.Open();

                mySqlCommand.Connection = this.MySqlConnection;
                x = mySqlCommand.ExecuteNonQuery();

            }
            else if (mySqlCommand.GetType().Equals(typeof(SqlCommand)))
            {
                this.SqlConnection = new SqlConnection(GetConnection());                                                                                                                                                                      
                if (mySqlCommand.Connection != null) { }
                else { mySqlCommand.Connection = this.SqlConnection; }                        
                this.SqlConnection.Open();                           

                mySqlCommand.Connection = this.SqlConnection;
                x = mySqlCommand.ExecuteNonQuery();                                                                                                                                                 
            }

            return x;
        }

        public object BulkCreate(List<MySqlCommand> mySqlCommands)
        {
            int x = -1;
            MySqlTransaction sqlTran = null;
            this.MySqlConnection = new MySqlConnection(GetConnection());
            this.MySqlConnection.Open();
            while (this.MySqlConnection.State != ConnectionState.Open) { }
            sqlTran = this.MySqlConnection.BeginTransaction();

            foreach (var cmd in mySqlCommands)
            {
                cmd.Connection = this.MySqlConnection;
                cmd.Transaction = sqlTran;
                int effected = cmd.ExecuteNonQuery();
            }

            sqlTran.Commit();
            if (sqlTran != null)
            {
                sqlTran.Dispose();
                sqlTran = null;
            }

            return x;
        }

        public int BulkCreate(List<SqlCommand> mySqlCommands)
        {
            SqlTransaction sqlTran = null;
            this.SqlConnection = new SqlConnection(GetConnection());
            this.SqlConnection.Open();
            while (this.MySqlConnection.State != ConnectionState.Open) { }
            sqlTran = this.SqlConnection.BeginTransaction();
            int effected = 0;
            foreach (var cmd in mySqlCommands)
            {
                cmd.Connection = this.SqlConnection;
                cmd.Transaction = sqlTran;
                effected += cmd.ExecuteNonQuery();
            }

            sqlTran.Commit();
            if (sqlTran != null)
            {
                sqlTran.Dispose();
                sqlTran = null;
            }

            return effected;
        }

        public IDataReader Read(IDbCommand command)
        {
            if (command.GetType().Equals(typeof(MySqlCommand)))
            {
                this.MySqlConnection = new MySqlConnection(GetConnection());
                this.DataAdapter = new MySqlDataAdapter();
                if (command.Connection != null) { }
                else { command.Connection = this.MySqlConnection; }

                this.MySqlConnection.Open();

                var cmd = command as MySqlCommand;
                this.Reader = cmd.ExecuteReader();
                return this.Reader;
            }
            else if (command.GetType().Equals(typeof(SqlCommand)))
            {
                this.SqlConnection = new SqlConnection(GetConnection());
                if (command.Connection != null) { }
                else { command.Connection = this.SqlConnection; }
                this.SqlConnection.Open();

                command.Connection = this.SqlConnection;
                var cmd = command as SqlCommand;
                this.SqlReader = cmd.ExecuteReader();
                return this.SqlReader;
            }
            return null;
        }

        public int Update(IDbCommand mySqlCommand)
        {
            int x = -1;
            if (mySqlCommand.GetType().Equals(typeof(MySqlCommand)))
            {
                this.MySqlConnection = new MySqlConnection(GetConnection());
                if (mySqlCommand.Connection != null) { }
                else { mySqlCommand.Connection = this.MySqlConnection; }
                this.MySqlConnection.Open();

                mySqlCommand.Connection = this.MySqlConnection;
                x = mySqlCommand.ExecuteNonQuery();
            }
            else if (mySqlCommand.GetType().Equals(typeof(SqlCommand)))
            {
                this.SqlConnection = new SqlConnection(GetConnection());
                if (mySqlCommand.Connection != null) { }
                else { mySqlCommand.Connection = this.SqlConnection; }
                this.SqlConnection.Open();

                mySqlCommand.Connection = this.SqlConnection;
                x = mySqlCommand.ExecuteNonQuery();
            }

            return x;
        }

        public int Delete(IDbCommand mySqlCommand)
        {
            int x = -1;
            if (mySqlCommand.GetType().Equals(typeof(MySqlCommand)))
            {
                this.MySqlConnection = new MySqlConnection(GetConnection());
                if (mySqlCommand.Connection != null) { }
                else { mySqlCommand.Connection = this.MySqlConnection; }
                this.MySqlConnection.Open();
                x = mySqlCommand.ExecuteNonQuery();

            }
            else if (mySqlCommand.GetType().Equals(typeof(SqlCommand)))
            {
                this.SqlConnection = new SqlConnection(GetConnection());
                if (mySqlCommand.Connection != null) { }
                else { mySqlCommand.Connection = this.SqlConnection; }
                this.SqlConnection.Open();
                x = mySqlCommand.ExecuteNonQuery();
            }

            return x;
        }

        public int Execute(IDbCommand mySqlCommand)
        {
            int x = -1;
            this.MySqlConnection = new MySqlConnection(GetConnection());
            if (mySqlCommand.Connection != null) { }
            else { mySqlCommand.Connection = this.MySqlConnection; }
            this.MySqlConnection.Open();
            x = mySqlCommand.ExecuteNonQuery();
            return x;
        }

        private string GetConnection()
        {
            var rv = string.Empty;
            if (this.ConnectionType == EConnection.Schema)
            {
                rv = ApplicationConfiguration.GetSchemaDrivenConnection();
            }
            else
            {
                rv = ApplicationConfiguration.GetDefaultConnection();
            }
            return rv;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool b)
        {
            if (this.MySqlConnection != null)
            {
                this.MySqlConnection.Dispose();
                this.MySqlConnection = null;
            }
            if (this.SqlConnection != null)
            {
                this.SqlConnection.Dispose();
                this.SqlConnection = null;
            }
            if (this.DataAdapter != null)
            {
                this.DataAdapter.Dispose();
                this.DataAdapter = null;
            }
            if (this.Reader != null)
            {
                this.Reader.Dispose();
                this.Reader = null;
            }
        }
    }
}
