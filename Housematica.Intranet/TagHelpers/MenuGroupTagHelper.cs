using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.TagHelpers
{
    public class MenuGroupTagHelper : TagHelper
    {
        public string Name { get; set; }



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
        }
    }
}
