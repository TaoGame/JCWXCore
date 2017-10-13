using JCSoft.WX.Framework.Extensions;
using JCSoft.WX.Framework.Models;
using JCSoft.WX.Framework.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
        public WxMessageController(IOptions<WXOptions> options)
        {
            wXOptions = options.Value;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(wXOptions);
        }

        [HttpPost]
        public JsonResult Post([FromBody]RequestMessage request)
        {
            return Json(request);
        }
    }
}
