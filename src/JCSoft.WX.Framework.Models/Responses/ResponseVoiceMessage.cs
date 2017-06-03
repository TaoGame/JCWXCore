using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [XmlRoot("xml")]
    public class ResponseVoiceMessage : ResponseMessage
    {
        public ResponseVoiceMessage() { }
        public ResponseVoiceMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return MsgType.Voice; }
        }

        public VoiceMessage Voice { get; set; }
    }

    
}
