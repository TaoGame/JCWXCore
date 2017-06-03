using JCSoft.WX.Framework.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [XmlRoot("xml")]
    public class ResponseVideoMessage : ResponseMessage
    {
        public ResponseVideoMessage() { }
        public ResponseVideoMessage(RequestMessage request)
            : base(request)
        {
        }
        public override MsgType MsgType
        {
            get { return MsgType.Video; }
        }

        public VideoMessage Video { get; set; }
    }

    
}
