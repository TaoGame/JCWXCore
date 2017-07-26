using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JCSoft.Core.Net.Http;
using JCSoft.WX.Framework.Api;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models;

namespace DemoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpFactory _httpFactory;
        private readonly IApiClient _client;
        public HomeController(IHttpFactory httpFactory, IApiClient client) {
            _httpFactory = httpFactory;
            _client = client;
        }
        public IActionResult Index()
        {
            ViewData["httpGet"] = _httpFactory
                .CreateHttp(HttpRequestActionType.Content)
                .Setup()
                .SetUrl("http://www.test.com")
                .SetContent("test content")
                .ToString();
            return View();
        }

        public IActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                var cliams = User.Claims.SingleOrDefault(s => s.Type == "WechatApppId");
                if(cliams != null)
                {
                    ViewData["Message"] = $"find cliams, the name is :{cliams.Type}, value is :{cliams.Value}";
                }
                else
                {
                    ViewData["Message"] = "cliams is null";
                }
               
            }
            else
            {
                ViewData["Message"] = "Your application description page.";
            }
            

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
