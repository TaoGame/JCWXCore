using JCSoft.WX.Framework.Models.Requests;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace JCSoft.WX.Framework.Models.Responses
{
    [Serializable]
    [XmlRoot("xml")]
    [XmlInclude(typeof(ResponseTextMessage))]
    [XmlInclude(typeof(ResponseNewsMessage))]
    [XmlInclude(typeof(ResponseMusicMessage))]
    [XmlInclude(typeof(ResponseImageMessage))]
    [XmlInclude(typeof(ResponseTransferCustomServiceMessage))]
    [XmlInclude(typeof(ResponseVideoMessage))]
    [XmlInclude(typeof(ResponseVoiceMessage))]
    [XmlInclude(typeof(ResponseEncryptMessage))]
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

        public string SingleSerializable()
        {

            var sw = new StringWriter();
            var xmlSettings = new XmlWriterSettings();
            xmlSettings.NewLineHandling = NewLineHandling.None;
            xmlSettings.Indent = false;
            xmlSettings.OmitXmlDeclaration = true;
            var xmlWriter = XmlWriter.Create(sw, xmlSettings);

            var xmlSerializer = new XmlSerializer(this.GetType());
            
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(xmlWriter, this, ns);

            return sw.ToString();
        }

        public static String Serializable(object response)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(response.GetType());
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, response, ns);

            return sw.ToString();
        }
    }
}
