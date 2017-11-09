using JCSoft.WX.Framework.Common;
using JCSoft.WX.Framework.Extensions;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Models.Responses;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JCSoft.WX.Mvc.Formatters
{
    public class WechatXmlSerializerOutputFormatter : XmlSerializerOutputFormatter
    {
        private readonly CryptRequestMessage _crypt;
        private MessageMode _messageMode;

        public WechatXmlSerializerOutputFormatter(string token, string aesKey, string appId, MessageMode mode)
            : base()
        {
            _messageMode = mode;
            _crypt = new CryptRequestMessage(token, aesKey, appId);

        }

        protected override bool CanWriteType(Type type)
        {
            if(type == typeof(ResponseMessage))
            {
                return true;
            }

            return base.CanWriteType(type);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (selectedEncoding == null)
            {
                throw new ArgumentNullException(nameof(selectedEncoding));
            }

            if (_messageMode == MessageMode.Cipher || _messageMode == MessageMode.Compatible)
            {
                if(context.ObjectType == typeof(ResponseMessage))
                {
                    var response = context.Object as ResponseMessage;
                    if(response != null)
                    {
                        var oldContent = response.SingleSerializable();
                        var noc = Cryptography.CreateRandCode(6);
                        var content = String.Empty;
                        var ret = _crypt.EncryptMsg(oldContent, DateTime.Now.ConvertToTimeStamp().ToString(), noc, ref content);

                        if (ret == 0 && !String.IsNullOrEmpty(content))
                        {
                            var buffer = selectedEncoding.GetBytes(content);
                            return context.HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                        }
                    }
                    
                }
            }

        
            return base.WriteResponseBodyAsync(context, selectedEncoding);
        }
    }
}
