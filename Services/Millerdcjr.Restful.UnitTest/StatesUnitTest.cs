using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Millerdcjr.Restful.Models;
using Generic.Common.Enums;
using System.Linq;
using System.Collections.Generic;
using Millerdcjr.DAL;
using Generic.Common.Configuration;
using Generic.Common.Extenders;

namespace Millerdcjr.Restful.UnitTest
{
    [TestClass]
    public class StatesUnitTest
    {
        Guid countryId = new Guid("AB4882CE-3674-4F9F-8A8A-B39060546211");
        Guid stateId = new Guid("F6C5E0C0-FD70-4046-B2A5-0798DF098221");

        [TestMethod]
        public void GetStatesTestMethod()
        {
            AssignmentService service = new AssignmentService();
            Response<Models.States> States = service.GetStates(countryId, "dm");
            Assert.IsNotNull(States);
            Assert.IsTrue(States.Result.Count > 0);
            Assert.IsTrue(States.ResponseType == EResponseType.Read);
        }

        [TestMethod]
        public void PostStatesTestMethod()
        {
            State State = new State(countryId, "abcd", "ab");
            AssignmentService service = new AssignmentService();
            Response<Models.States> States = service.PostStates(State);
            Assert.IsNotNull(States);
            Assert.IsTrue(States.Result.Count > 0);
            Assert.IsTrue(States.ResponseType == EResponseType.Created);
            var ids = States.Result.Select(x => x.ID);
            Response<Models.States> dStates = null;

            foreach (var id in ids)
            {
                dStates = service.DeleteStates(countryId, id);
            }
        }

        [TestMethod]
        public void DeleteStatesTestMethod()
        {
            State State = new State(countryId, "abcd", "ab");
            AssignmentService service = new AssignmentService();
            Response<Models.States> States = service.PostStates(State);
            var ids = States.Result.Select(x => x.ID);
            List<Response<Models.States>> dStates = new List<Response<States>>();

            foreach (var id in ids)
            {
                dStates.Add(service.DeleteStates(countryId, id));
            }

            Assert.IsNotNull(dStates);
            Assert.IsTrue(dStates.Count > 0);
        }

        [TestMethod]
        public void ReadTestMethod()
        {
            AssignmentService service = new AssignmentService();
            var state = service.GetStates(countryId, stateId);
            Assert.IsNotNull(state);
            Assert.AreEqual(state.Name, "do Not Delete");
            Assert.AreEqual(state.IsoCode2, "dm");
        }
    }
}
