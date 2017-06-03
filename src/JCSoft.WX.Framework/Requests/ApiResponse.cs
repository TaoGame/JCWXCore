using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCSoft.WX.Framework.Requests
{
    public abstract class ApiResponse
    {
        public bool IsError
        {
            get
            {
                return ErrorCode != 0;
            }
        }



        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            if (IsError)
            {
                return String.Format("errcode:{0}, errmsg:{1}", ErrorCode, ErrorMessage);
            }

            return base.ToString();
        }
    }
}
