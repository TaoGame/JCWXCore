using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取消息发送分布数据（getupstreammsgdist）	
    /// </summary>
    public class DatacubeGetUpStreamMsgDistRequest : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "/datacube/getupstreammsgdist?access_token={0}"; }
        }
    }
}
