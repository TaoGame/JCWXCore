using JCSoft.WX.Framework.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IApiClient _client;
        public BaseController(IApiClient client)
        {
            _client = client;
        }


        public string AppId
        {
            get
            {
                return User?.Claims?.SingleOrDefault(c => c.Type == "appid")?.Value;
            }
        }

        public string AppSecret
        {
            get
            {
                return User?.Claims?.SingleOrDefault(c => c.Type == "appSecret")?.Value;
            }
        }

        public string AccessToken
        {
            get
            {
                return User?.Claims?.SingleOrDefault(c => c.Type == "token")?.Value;
            }
        }
    }
}
