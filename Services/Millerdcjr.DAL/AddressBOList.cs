using Generic.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millerdcjr.DAL
{
    public class AddressBOList : List<AddressBO>, ICrudOperations<AddressBO, AddressBOCriteria>
    {
        public AddressBOList()
        {

        }

        public void Read(AddressBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }

        public AddressBO Update(AddressBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }

        public AddressBO Delete(AddressBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }

        public AddressBO Create(AddressBO criteria)
        {
            throw new NotImplementedException();
        }

        public AddressBO Update(AddressBO criteria)
        {
            throw new NotImplementedException();
        }

        public AddressBO Delete(AddressBO criteria)
        {
            throw new NotImplementedException();
        }

        public AddressBO Create(AddressBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }
    }
}
