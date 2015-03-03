using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Generic.Common.Interfaces
{
    public interface ICrudOperations<T, Criteria>
    {
        T Create(Criteria criteriaObj);
        void Read(Criteria criteriaObj);
        T Update(Criteria criteriaObj);
        T Delete(Criteria criteriaObj);
    }
}
