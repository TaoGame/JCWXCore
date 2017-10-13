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

namespace JCSoft.WX.Mvc.Formatters
{
    public class WechatXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        private readonly WXOptions _options;
        private readonly CryptRequestMessage _crypt;
        public WechatXmlSerializerInputFormatter()
            : base()
        {
            
            _crypt = new CryptRequestMessage(_options?.Token, _options?.EncodingAESKey, _options?.AppId);

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

                    if((_options.MessageMode == MessageMode.Cipher || _options.MessageMode == MessageMode.Compatible) && 
                        inputRequestMessage is EncryptRequestMessage)
                    {
                        var encryptMessage = inputRequestMessage as EncryptRequestMessage;
                        var plainMessage = String.Empty;
                        var sMsgSignature = context.HttpContext.Request.Query["msg_signature"];
                        var sTimeStamp = context.HttpContext.Request.Query["timestamp"];
                        var sNonce = context.HttpContext.Request.Query["nonce"];
                        var ret = _crypt.DecryptMsg(sMsgSignature, sTimeStamp, sNonce, encryptMessage.EncryptMessage, ref plainMessage);
                        if(ret > 0)
                        {
                            using(var stringStream = new MemoryStream(Encoding.UTF8.GetBytes(plainMessage)))
                            using (var stringReader = XmlReader.Create(stringStream))
                            {
                                inputRequestMessage = RequestMessageFactory.CreateRequestMessage(xmlReader);
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
