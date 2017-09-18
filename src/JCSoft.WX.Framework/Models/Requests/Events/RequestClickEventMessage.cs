using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestClickEventMessage : RequestEventMessage
    {
        public RequestClickEventMessage(XElement xml)
            : base(xml)
        {
            EventKey = xml.Element("EventKey").Value;     
        }

        public string EventKey { get; set; }
    }
}
