using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    /// <summary>
    /// 获取接口分析分时数据（getinterfacesummaryhour）	
    /// </summary>
    public class DatacubeGetInterfaceSummaryHourRequest : DatacubeGetInterfaceRequest
    {
        protected override string UrlFormat
        {
            get { return "/datacube/getinterfacesummaryhour?access_token={0}"; }
        }
    }
}
