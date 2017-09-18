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
    public abstract class BaseApiController<T> : BaseController
        where T : ApiResponse, new()
    {
        public BaseApiController(IApiClient client) : base(client)
        {
        }

        public JsonResult Get()
        {
            var request = GetApiRequest();

            var response = _client.Execute(request);

            return Json(response);
        }

        protected abstract ApiRequest<T> GetApiRequest();
    }
}
