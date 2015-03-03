using Generic‎.Common‎.Enums;
using Generic‎.Common‎.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Generic‎.Common‎.DataAccessLayer
{
    public class SqlWrapper : ISqlHelper, IDisposable
    {
        public SqlWrapper(EConnection connectionType)
        {
            this.DataSet = null;
            this.MySqlHelper = new MySqlConnectionHelper(connectionType);
        }

        private IDataReader DataSet { get; set; }
        private MySqlConnectionHelper MySqlHelper { get; set; }

        public object Create(IDbCommand command)
        {
            object rv = new object();
            if (command.GetType().Equals(typeof(MySqlCommand)))
            {
                rv = this.MySqlHelper.Create(command);
            }
            else if (command.GetType().Equals(typeof(SqlCommand)))
            {
                rv = this.MySqlHelper.Create(command);
            }

            return rv;
        }

        public object BulkCreate(List<MySqlCommand> commands)
        {
            object rv = new object();
            if (commands.GetType().Equals(typeof(List<MySqlCommand>)))
            {
                rv = this.MySqlHelper.BulkCreate(commands);
            }
            return rv;
        }

        public Message BulkCreate(List<SqlCommand> commands)
        {
            Message rv = new Message();

            if (commands.GetType().Equals(typeof(List<SqlCommand>)))
            {
                rv.Quantity = this.MySqlHelper.BulkCreate(commands);

                if (rv.Quantity == commands.Count)
                {
                    rv.EAcknowledgementCode = EAcknowledgementCode.Accepted;
                }
                else if (rv.Quantity == 0)
                {
                    rv.EAcknowledgementCode = EAcknowledgementCode.Rejected;
                }
                else if (rv.Quantity < commands.Count)
                {
                    rv.EAcknowledgementCode = EAcknowledgementCode.PartialRejection;
                }
                
                rv.EMessage = EMessage.Create;
                    
            }
            return rv;
        }

        public IDataReader Read(IDbCommand command)
        {
            if (command.GetType().Equals(typeof(MySqlCommand)))
            {
                this.DataSet = this.MySqlHelper.Read(command);
            }
            else if (command.GetType().Equals(typeof(SqlCommand)))
            {
                this.DataSet = this.MySqlHelper.Read(command);
            }

            return this.DataSet;
        }

        public int Update(IDbCommand command)
        {
            int rv = 0;
            if (command.GetType().Equals(typeof(MySqlCommand)))
            {
                rv = this.MySqlHelper.Update(command);
            }
            //else if (command.GetType().Equals(typeof(SqlCommand)))
            //{
            //}
            return rv;
        }

        public int Delete(IDbCommand command)
        {
            int rv = 0;

            if (command.GetType().Equals(typeof(MySqlCommand)))
            {
                rv = this.MySqlHelper.Delete(command);
            }
            //else if (command.GetType().Equals(typeof(SqlCommand)))
            //{
            //}

            return rv;
        }

        public void Execute(IDbCommand command)
        {
            int rv = 0;

            if (command.GetType().Equals(typeof(MySqlCommand)))
            {
                rv = this.MySqlHelper.Delete(command);
            }
            //else if (command.GetType().Equals(typeof(SqlCommand)))
            //{
            //}
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool v)
        {
            if (v)
            {
                if (this.DataSet != null)
                {
                    this.DataSet.Dispose();
                    this.DataSet = null;
                }
                if (this.MySqlHelper != null)
                {
                    this.MySqlHelper.Dispose();
                    this.MySqlHelper = null;
                }
            }
        }
    }
}
