using JCSoft.WX.Framework.Models.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCSoft.WX.Framework.Models.ApiRequests;
using JCSoft.WX.Framework.Api;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    [Route("api/menudelete")]
    public class MenuDeleteController : BaseApiController<MenuDeleteResponse>
    {
        public MenuDeleteController(IApiClient client) : base(client)
        {
        }

        protected override ApiRequest<MenuDeleteResponse> GetApiRequest()
        {
            return new MenuDeleteRequest
            {
                AccessToken = AccessToken
            };
        }
    }
}
