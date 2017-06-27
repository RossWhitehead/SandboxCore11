namespace SandboxCore11.TagHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public class ProgressBarTagHelper : TagHelper
    {
        public string Stage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int progress = 0;
            string cssClass = "progress-bar progress-bar-striped";

            switch (Stage)
            {
                case "Requested":
                    progress = 25;
                    cssClass += " progress-bar-info";
                    break;
                case "Confirmed":
                    progress = 50;
                    cssClass += " progress-bar-warning";
                    break;
                case "Received":
                    progress = 100;
                    cssClass += " progress-bar-success";
                    break;
                case "Cancelled":
                    progress = 100;
                    cssClass += " progress-bar-danger";
                    break;
            }

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", cssClass);
            output.Attributes.SetAttribute("style", $"width: {progress}%");
        }
    }
}
