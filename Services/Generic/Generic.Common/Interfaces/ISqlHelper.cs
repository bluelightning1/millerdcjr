using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Generic‎.Common‎.Interfaces
{
    public interface ISqlHelper : IDisposable
    {
        object Create(IDbCommand command);
        IDataReader Read(IDbCommand command);
        int Update(IDbCommand command);
        int Delete(IDbCommand command);
    }
}
