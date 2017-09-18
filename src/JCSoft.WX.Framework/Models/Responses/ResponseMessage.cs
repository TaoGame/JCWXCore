using JCSoft.WX.Framework.Models.Requests;
using System;
using System.IO;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [Serializable]
    [XmlRoot("xml")]
    public abstract class ResponseMessage : WXMessage
    {
        public ResponseMessage() { }

        public ResponseMessage(RequestMessage request)
        {
            this.FromUserName = request.ToUserName;
            this.ToUserName = request.FromUserName;
        }

        public override MsgType MsgType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public String Serializable()
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(this.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, this, ns);

            return sw.ToString();
        }
    }
}
