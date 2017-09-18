using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MediaGetRequest : ApiRequest<MediaGetResponse>
    {
        public string MediaId { get; set; }

        public override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}"; }
        }

        public override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, MediaId);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }

        public override bool NotHasResponse
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
