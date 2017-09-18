using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCSoft.WX.Framework.Api;
using Microsoft.AspNetCore.Mvc;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace DemoWeb.Controllers
{
    [Route("api/menuQuery")]
    public class MenuQueryController : BaseApiController<MenuGetResponse>
    {
        public MenuQueryController(IApiClient client) : base(client)
        {
        }

        protected override ApiRequest<MenuGetResponse> GetApiRequest()
        {
            return new MenuGetRequest
            {
                AccessToken = AccessToken
            };
        }
    }
}
