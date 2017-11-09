using System;
using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestEventMessage : RequestMessage
    {
        public RequestEventMessage(XElement xml)
            : base(xml)
        {
            this.Event = (Event)Enum.Parse(typeof(Event), xml.Element("Event").GetValue(), true);
        }

        public Event Event { get; set; }

        public override MsgType MsgType
        {
            get { return MsgType.Event; }
        }
    }
}
