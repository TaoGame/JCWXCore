using System;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;
using JCSoft.WX.Framework.Models.Requests;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.Options;
using JCSoft.WX.Framework.Extensions;
using JCSoft.WX.Framework.Common;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;

namespace JCSoft.WX.Mvc.Formatters
{
    public class WechatXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        private readonly CryptRequestMessage _crypt;
        private MessageMode _messageMode;
        public WechatXmlSerializerInputFormatter(string token, string aesKey, string appId, MessageMode mode)
            : base()
        {
            _messageMode = mode;
            _crypt = new CryptRequestMessage(token, aesKey, appId);

        }


        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            if (context.ModelType == typeof(RequestMessage))
            {
                var request = context.HttpContext.Request;
                if (!request.Body.CanSeek)
                {
                    BufferingHelper.EnableRewind(request);
                    Debug.Assert(request.Body.CanSeek);

                    await request.Body.DrainAsync(CancellationToken.None);
                    request.Body.Seek(0L, SeekOrigin.Begin);
                }

                using (var xmlReader = CreateXmlReader(new NonDisposableStream(request.Body), encoding))
                {
                    var inputRequestMessage = RequestMessageFactory.CreateRequestMessage(xmlReader);

                    if((_messageMode == MessageMode.Cipher || _messageMode == MessageMode.Compatible) && 
                        inputRequestMessage is RequestEncryptMessage)
                    {
                        var encryptMessage = inputRequestMessage as RequestEncryptMessage;
                        var plainMessage = String.Empty;
                        var sMsgSignature = context.HttpContext.Request.Query["msg_signature"];
                        var sTimeStamp = context.HttpContext.Request.Query["timestamp"];
                        var sNonce = context.HttpContext.Request.Query["nonce"];
                        var ret = _crypt.DecryptMsg(sMsgSignature, sTimeStamp, sNonce, encryptMessage.EncryptMessage, ref plainMessage);
                        if(ret == 0)
                        {
                            using(var stringStream = new MemoryStream(encoding.GetBytes(plainMessage)))
                            using (var stringReader = CreateXmlReader(stringStream, encoding))
                            {
                                inputRequestMessage = RequestMessageFactory.CreateRequestMessage(stringReader);
                            }
                        }
                    }

                    return InputFormatterResult.Success(inputRequestMessage);
                }


            }

            return await base.ReadRequestBodyAsync(context, encoding);
        }
    }
}
