using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWeb.Pages.Partials
{
    public class CodePartailModel : PageModel
    {
        public Func<string> Code { get; set; }

        public int Index { get; set; }

        public bool ShowTestButtons { get; set; }

        public void OnGet()
        {
        }
    }
}