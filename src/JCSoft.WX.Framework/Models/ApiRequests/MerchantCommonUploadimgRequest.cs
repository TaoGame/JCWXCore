using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantCommonUploadimgRequest : ApiRequest<MerchantCommonUploadimgResponse>
    {
        public string FilePath { get; set; }

        public string FileName { get; set; }

        internal override HttpRequestActionType Method => HttpRequestActionType.File;

        protected override string UrlFormat
        {
            get { return "/merchant/common/upload_img?access_token={0}&filename={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, FileName);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            return FilePath;
        }
    }
}
