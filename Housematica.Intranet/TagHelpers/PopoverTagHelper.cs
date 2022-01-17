using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.TagHelpers
{
    public class PopoverTagHelper : TagHelper
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public string Element { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"<span class='label pulse mr - 10' data-toggle='popover' title='{Title}' data-html='true' data-content='{Value}'><span class='position-relative'>{Element}</span><span class='pulse-ring'></span></span>");
        }
    }
}
