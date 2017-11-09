using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public class RequestMassSendEventMessage : RequestEventMessage
    {
        public RequestMassSendEventMessage(XElement xml)
            : base(xml)
        {
            MsgId = long.Parse(xml.Element("MsgID").GetValue());
            Status = xml.Element("Status").GetValue();
            TotalCount = int.Parse(xml.Element("TotalCount").GetValue());
            FilterCount = int.Parse(xml.Element("FilterCount").GetValue());
            SentCount = int.Parse(xml.Element("SentCount").GetValue());
            ErrorCount = int.Parse(xml.Element("ErrorCount").GetValue());
        }

        public string Status { get; set; }

        public int TotalCount { get; set; }

        public int FilterCount { get; set; }

        public int SentCount { get; set; }

        public int ErrorCount { get; set; }
    }
}
