using Generic.Common.Interfaces;
using Millerdcjr.DAL;
using Millerdcjr.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Generic.Common.Extenders;

namespace Millerdcjr.Restful.Models
{
    public class States : List<State>, ICrudOperations<State, StateBOCriteria>
    {
        public States()
        {
        }

        public States(StateBO state)
        {
            if (state != null)
            {
                this.Add(new State
                {
                    ID = state.ID,
                    IsoCode2 = state.IsoCode2,
                    Name = state.Name
                });
            }
        }

        public States(StateBOList states)
        {
            Load(states);
        }

        public States(State orig)
        {
            if (orig != null)
                this.Add(orig);
        }

        public State Create(StateBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }

        public void Read(StateBOCriteria criteriaObj)
        {
            StateBOList list = new StateBOList();

            try
            {
                list.Read(criteriaObj);

                Load(list);

                list.Clear();
                list = null;
            }
            catch (Exception ex)
            {
                //provide some logging...
                LogHandler.Write(Assembly.GetCallingAssembly().FullName, MethodBase.GetCurrentMethod().DeclaringType.Name, ex, criteriaObj.LogLocation, null, null);

                throw;
            }
        }

        public State Update(StateBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }

        public State Delete(StateBOCriteria criteriaObj)
        {
            throw new NotImplementedException();
        }

        private void Load(StateBOList list)
        {

            if (list == null || list.Count() < 0)
                throw new Exception("The List of countries must be initialized or have a count greater than or equal to zero.");
            // TODO: Complete member initialization
            this.AddRange((from c in list
                           select new State
                           {
                               ID = c.ID,
                               Name = c.Name,
                               CountryID = c.CountryID
                                ,  IsoCode2 = c.IsoCode2
                           }));
        }
    }
}
