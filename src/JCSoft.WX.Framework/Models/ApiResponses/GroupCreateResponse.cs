using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JCSoft.WX.Framework.Models.ApiResponses
{
    public class GroupCreateResponse : ApiResponse
    {
        public Group Group { get; set; }

        public override string ToString()
        {
            if (IsError)
                return base.ToString();

            return String.Format("groupname:{0}, groupid:{1}", Group.Name, Group.ID);
        }
    }
}
