using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取图文群发总数据（getarticletotal）	
    /// </summary>
    public class DatacubeGetarticletotalRequest : DatacubeGetarticlesummaryRequest
    {
        protected override string UrlFormat
        {
            get
            {
                return "/datacube/getarticletotal?access_token={0}";
            }
        }
    }
}
