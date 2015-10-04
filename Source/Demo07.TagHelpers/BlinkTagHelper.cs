using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo07.TagHelpers
{
    [TargetElement("blink", Attributes = "interval")]
    public class BlinkTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // try and get the parameter first
            int interval;

            if (!int.TryParse(context.AllAttributes["interval"].Value.ToString(), out interval)) return;


            // render the actual markup
            output.TagName = null;

            var id = "blink_" + Guid.NewGuid().ToString("N");
            output.PreContent.AppendFormat("<div id=\"{0}\">", id);

            output.PostElement.Append("<script type='text/javascript'>setInterval(function() {");
            output.PostElement.AppendFormat("$('#{0}').css('visibility' , $('#{0}').css('visibility') === 'hidden' ? '' : 'hidden');", id);
            output.PostElement.AppendFormat("}}, {0});</script>", interval);

            output.PostContent.Append("</div>");
        }
    }
}
