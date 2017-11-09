using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [XmlRoot("xml")]
    public class ResponseImageMessage : ResponseMessage
    {
        public ResponseImageMessage() { }
        public ResponseImageMessage(RequestMessage request)
            : base(request)
        {
        }

        public ImageMessage Image { get; set; }

        public override MsgType MsgType
        {
            get { return MsgType.Image; }
        }
    }
}
