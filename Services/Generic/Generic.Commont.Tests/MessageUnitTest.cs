using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generic.Common.Enums;

namespace Generic.Common.Tests
{
    [TestClass]
    public class MessageUnitTest
    {
        [TestMethod]
        public void MessageTestMethod()
        {
            Message message = new Message();
            message.EAcknowledgementCode = EAcknowledgementCode.Accepted;
            message.EMessage = EMessage.Create;
            message.Key = Guid.NewGuid();
            message.Quantity = 1;
            message.Text = "";
            Assert.IsNotNull(message);
        }
    }
}
