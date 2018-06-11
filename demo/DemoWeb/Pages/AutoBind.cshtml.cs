using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCSoft.WX.Framework.Api;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWeb.Pages
{
    public class AutoBindModel : PageModel
    {
        private readonly IApiClient _client;
        public AutoBindModel(IApiClient apiClient)
        {
            _client = apiClient;
        }
        
        private const string _appId = "wxdc3ee459a9b8f109";
        private const string _appSecret = "9e18517ce82628615105213ce463f1d2";

        public void OnGet([FromQuery]string code)
        {
            if (!String.IsNullOrWhiteSpace(code))
            {
                AccessTokenCode = _client.Execute(new AccessTokenCodeRequest
                {
                    AppId = _appId,
                    AppSecret = _appSecret,
                    Code = code
                });
            }
        }

        public AccessTokenCodeResponse AccessTokenCode { get; set; }
    }
}