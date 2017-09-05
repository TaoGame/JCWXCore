using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCSoft.WX.Framework.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace DemoWeb.Pages
{
    public class CustomerMenuCreateModel : LoginedPageModel
    {
        public CustomerMenuCreateModel(IMemoryCache cache, IApiClient client) : base(cache, client)
        {
        }

        public string Code { get; set; }

        public void OnGet()
        {
           
        }
    }
}