using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantCommonUploadimgRequest : ApiRequest<MerchantCommonUploadimgResponse>
    {
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public override string Method
        {
            get { return FILEMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/common/upload_img?access_token={0}&filename={1}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, FileName);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return FilePath;
        }
    }
}
