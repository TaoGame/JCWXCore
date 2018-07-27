using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取消息发送月数据（getupstreammsgmonth）
    /// </summary>
    public class DatacubeGetUpStreamMsgMonthRequest : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "/datacube/getupstreammsgmonth?access_token={0}"; }
        }
    }
}
