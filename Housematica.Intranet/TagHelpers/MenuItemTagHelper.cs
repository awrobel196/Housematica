using Housematica.Intranet.TagHelpers.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet.TagHelpers
{
    public class MenuItemTagHelper : TagHelper
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IconsDictionary iconsDictionary = new IconsDictionary();

            output.Content.SetHtmlContent($"<li class='menu-item' data-menu-toggle='hover' aria-haspopup='true'><a href='/{Controller}/{Action}' class='menu-link'><span class='svg-icon menu-icon'>{iconsDictionary.GetIcon(Icon)}</span><span class='menu-text'>{Name}</span></a></li>");
        }
    }
}
