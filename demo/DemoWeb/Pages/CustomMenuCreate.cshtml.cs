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
    public class CustomMenuCreateModel : LoginedPageModel
    {
        public CustomMenuCreateModel(IMemoryCache cache, IApiClient client) : base(cache, client)
        {
        }

        public string Code { get; set; }

        public override int Index => 0;

        public override int SubIndex => 2;

        public void OnGet()
        {
            
        }
    }
}