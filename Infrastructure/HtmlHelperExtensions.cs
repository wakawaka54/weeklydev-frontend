using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestApp.Models.Infrastructure;

namespace TestApp.Infrastructure
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent AddApplicationMessage(this IHtmlHelper helper, ApplicationMessage message)
        {
            HtmlContentBuilder content = new HtmlContentBuilder();
            string alertClass = $"alert-{message.MessageType.ToString().ToLower()}";
            string htmlContent =
                $"<div class=\"alert {alertClass} site-alert center-col\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>{message.Message}</div>";

            return content.SetHtmlContent(htmlContent);
        }
    }
}
