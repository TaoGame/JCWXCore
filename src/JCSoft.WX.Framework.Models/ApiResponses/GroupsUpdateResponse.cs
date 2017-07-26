using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class GroupsUpdateResponse : ApiResponse
    {
        public override string ToString()
        {
            if (IsError)
                return base.ToString();
            return String.Format("success, msg:{0}", ErrorMessage);
        }
    }
}
