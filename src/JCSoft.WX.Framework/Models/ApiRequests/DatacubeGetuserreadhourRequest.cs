using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取图文统计分时数据（getuserreadhour）	
    /// </summary>
    public class DatacubeGetuserreadhourRequest : DatacubeGetarticlesummaryRequest
    {
        protected override string UrlFormat
        {
            get
            {
                return "/datacube/getuserreadhour?access_token={0}";
            }
        }
    }
}
