using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace JCSoft.WX.Framework.Models.Requests
{
    public static class RequestMessageFactory
    {
        private const string WechatRequestXmlRoot = "xml";
        public static RequestMessage CreateRequestMessage(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("xml reader is null");
            }

            var xmlDocmnet = XDocument.Load(reader);
            var xml = xmlDocmnet.Element(WechatRequestXmlRoot);

            return RequestMessageByMsgType(xml);
        }

        private static RequestMessage RequestMessageByMsgType(XElement xml)
        {
            var msgTypeString = xml.Element("MsgType").GetValue();
            MsgType msgType = MsgType.Text;
            if (Enum.TryParse<MsgType>(msgTypeString, true, out msgType))
            {
                switch (msgType)
                {
                    case MsgType.Text:
                        return new RequestTextMessage(xml);
                    case MsgType.Image:
                        return new RequestImageMessage(xml);
                    case MsgType.Voice:
                        return new RequestVoiceMessage(xml);
                    case MsgType.Video:
                        return new RequestVideoMessage(xml);
                    case MsgType.ShortVideo:
                        return new RequestShortVideoMessage(xml);
                    case MsgType.Link:
                        return new RequestLinkMessage(xml);
                    case MsgType.Location:
                        return new RequestLocationMessage(xml);
                    case MsgType.Event:
                        return EventRequestMessageByEventType(xml);
                    default:
                        return IsEncryptMessage(xml);

                }
            }
            else
            {
                return IsEncryptMessage(xml);
                //throw new ArgumentOutOfRangeException("msg Type can't format");
            }
        }

        private static RequestMessage IsEncryptMessage(XElement xml)
        {
            if (!String.IsNullOrEmpty(xml.Element("Encrypt").GetValue()))
            {
                return new EncryptRequestMessage(xml);
            }

            throw new ArgumentOutOfRangeException("msg Type can't format");
        }

        private static RequestEventMessage EventRequestMessageByEventType(XElement xml)
        {
            var eventTypeString = xml.Element("Event").GetValue();
            var eventType = Event.Subscribe;
            if (Enum.TryParse<Event>(eventTypeString, true, out eventType))
            {
                switch (eventType)
                {
                    case Event.Scan:
                        return new RequestQREventMessage(xml);
                    case Event.Subscribe:
                        return xml.Element("EventKey") != null ?
                            new RequestQREventMessage(xml) :
                            new RequestEventMessage(xml);
                    case Event.Location:
                        return new RequestLocationEventMessage(xml);
                    case Event.Click:
                        return new RequestClickEventMessage(xml);
                    case Event.View:
                        return new RequestViewEventMessage(xml);
                    case Event.Unsubscribe:
                    default:
                        return new RequestEventMessage(xml);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("event Type can't format");
            }
        }
    }
}
