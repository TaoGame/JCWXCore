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

namespace JCSoft.WX.Mvc.Formatters
{
    public class WechatXmlSerializerInputFormatter : XmlSerializerInputFormatter
    {
        public WechatXmlSerializerInputFormatter()
            : base()
        {
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

                    return InputFormatterResult.Success(inputRequestMessage);
                }


            }

            return await base.ReadRequestBodyAsync(context, encoding);
        }
    }
}
