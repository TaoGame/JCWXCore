using JCSoft.WX.Framework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb
{
    public class BasePageModel : PageModel
    {
        protected readonly IMemoryCache _cache;
        protected readonly IApiClient _client;



        public BasePageModel(IMemoryCache cache, IApiClient client)
        {
            _cache = cache;
            _client = client;
        }

        public string Message { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; } = true;
    }

    [Authorize]
    public abstract class LoginedPageModel : BasePageModel
    {
        public LoginedPageModel(IMemoryCache cache, IApiClient client) : base(cache, client)
        {
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

        public abstract int Index { get;}

        public abstract int SubIndex { get; }
    }
}
