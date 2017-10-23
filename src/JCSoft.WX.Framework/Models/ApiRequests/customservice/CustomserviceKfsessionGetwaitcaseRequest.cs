using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class CustomserviceKfsessionGetwaitcaseRequest : ApiGetNeedTokenRequest<CustomserviceKfsessionGetwaitcaseResponse>
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/customservice/kfsession/getwaitcase?access_token={0}"; }
        }
    }
}
