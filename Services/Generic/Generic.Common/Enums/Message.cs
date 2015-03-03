using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic.Common.Enums
{
    public class Message
    {
        public EMessage EMessage { get; set; }
        public EAcknowledgementCode EAcknowledgementCode { get; set; }
        public string Text { get; set; }
        public int Quantity { get; set; }
        public Guid Key { get; set; }

        public Message()
        {
            this.Text = string.Empty;
            this.EMessage = EMessage.Unknown;
            this.EAcknowledgementCode = Enums.EAcknowledgementCode.Unknown;
            this.Quantity = 0;
        }
    }
}
