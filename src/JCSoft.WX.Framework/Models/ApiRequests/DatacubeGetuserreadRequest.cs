using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取图文统计数据（getuserread）
    /// </summary>
    public class DatacubeGetuserreadRequest : DatacubeGetarticlesummaryRequest
    {
        protected override string UrlFormat
        {
            get
            {
                return "/datacube/getuserread?access_token={0}";
            }
        }
    }
}
