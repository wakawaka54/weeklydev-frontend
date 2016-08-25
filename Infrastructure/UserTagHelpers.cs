using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TestApp.Infrastructure
{
    public class UserTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string username = context.AllAttributes["data-username"].Value.ToString();
            string image = context.AllAttributes["data-userimage"].Value.ToString();

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            base.Process(context, output);
        }
    }
}
