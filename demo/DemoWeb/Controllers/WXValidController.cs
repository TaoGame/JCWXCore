using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoWeb.Controllers
{
    public class WXValidController : Controller
    {
        private readonly ILogger<WXValidController> _logger;
        public WXValidController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WXValidController>();
        }

        public string Index(string echostr, string signature, string timestamp)
        {
            _logger.LogInformation($"echostr:{echostr}, signature:{signature}, timestamp:{timestamp}");
            return echostr;
        }
    }
}