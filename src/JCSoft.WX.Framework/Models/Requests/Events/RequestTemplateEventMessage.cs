using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Request.Requests
{
    public class RequestTemplateEventMessage : RequestEventMessage
    {
        public RequestTemplateEventMessage(XElement xml)
            : base(xml)
        {
            this.Status = xml.Element("Status").GetValue();
        }


        public string Status { get; set; }

        public override MsgType MsgType
        {
            get { return MsgType.Event; }
        }
    }
}
