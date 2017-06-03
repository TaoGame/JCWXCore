using JCSoft.WX.Framework.Models.Requests;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [XmlRoot("xml")]
    public class ResponseNewsMessage : ResponseMessage
    {
        public ResponseNewsMessage() { }
        public ResponseNewsMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return MsgType.News; }
        }

        public int ArticleCount { get; set; }

        [XmlArrayItem("item")]
        public List<ArticleMessage> Articles { get; set; }
    }
}
