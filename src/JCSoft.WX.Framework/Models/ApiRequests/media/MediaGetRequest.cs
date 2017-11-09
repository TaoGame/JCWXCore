using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MediaGetRequest : ApiRequest<MediaGetResponse>
    {
        public string MediaId { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Get; }
        }

        protected override string UrlFormat
        {
            get { return "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, MediaId);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            throw new NotImplementedException();
        }

        internal override bool NotHasResponse
        {
            get
            {
                return true;
            }
        }

        public override void Validate()
        {
            base.Validate();
            if (String.IsNullOrEmpty(MediaId))
            {
                throw new ArgumentNullException("MediaId is null");
            }
        }
    }
}
