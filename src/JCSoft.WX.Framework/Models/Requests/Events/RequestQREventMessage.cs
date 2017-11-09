using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestQREventMessage : RequestEventMessage
    {
        public RequestQREventMessage(XElement xml)
            : base(xml)
        {
            this.EventKey = xml.Element("EventKey").GetValue();
            this.Ticket = xml.Element("Ticket").GetValue();
        }

        public string EventKey { get; set; }

        public string Ticket { get; set; }
    }
}
