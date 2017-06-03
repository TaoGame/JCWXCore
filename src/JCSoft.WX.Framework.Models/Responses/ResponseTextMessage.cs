using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [XmlRoot("xml")]
    public class ResponseTextMessage : ResponseMessage
    {
        public ResponseTextMessage() { }
        public ResponseTextMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return MsgType.Text; }
        }

        public string Content { get; set; }
    }
}
