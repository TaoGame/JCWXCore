using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestViewEventMessage : RequestEventMessage
    {
        public RequestViewEventMessage(XElement xml)
            : base(xml)
        {
            EventKey = xml.Element("EventKey").GetValue();     
        }

        public string EventKey { get; set; }
    }
}
