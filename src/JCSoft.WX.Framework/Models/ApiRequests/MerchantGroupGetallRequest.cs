using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantGroupGetallRequest : ApiRequest<MerchantGroupGetallResponse>
    {
        public override string Method
        {
            get { return GETMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/group/getall?access_token={0}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }
    }
}
