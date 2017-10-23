using JCSoft.WX.Framework.Extensions;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Models.Requests;
using JCSoft.WX.Framework.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassivityRequestMessageDemo.Controllers
{
    [Route("api/wx")]
    public class WxMessageController : Controller
    {
        private WXOptions wXOptions;
        private ILogger<WxMessageController> _logger;
        public WxMessageController(IOptions<WXOptions> options, ILoggerFactory loggerFactory)
        {
            wXOptions = options.Value;
            _logger = loggerFactory.CreateLogger<WxMessageController>();
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(wXOptions);
        }

        [HttpPost]
        public ResponseMessage Post([FromBody]RequestMessage request)
        {
            var textRequest = request as RequestTextMessage;
            var response = new ResponseTextMessage
            {
                FromUserName = "jamesying",
                ToUserName = "candy",
                Content = textRequest?.Content ?? "this is a test!",
                CreateTime = DateTime.Now.Ticks,
            };

            _logger.LogInformation("[Recive a Message]\r\n request is :{0} \r\n response:{1}", 
                JsonConvert.SerializeObject(request), 
                JsonConvert.SerializeObject(response));

            return response;
        }

        [HttpPut]
        public JsonResult Put([FromBody]RequestMessage request)
        {
            return Json(request);
        }
    }
}
