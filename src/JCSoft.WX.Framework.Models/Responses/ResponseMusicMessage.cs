using JCSoft.WX.Framework.Models.Requests;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [XmlRoot("xml")]
    public class ResponseMusicMessage : ResponseMessage
    {
        public ResponseMusicMessage() { }
        public ResponseMusicMessage(RequestMessage request)
            : base(request)
        {
        }

        public override MsgType MsgType
        {
            get { return MsgType.Music; }
        }

        public MusicMessage Music { get; set; }
    }

    
}
