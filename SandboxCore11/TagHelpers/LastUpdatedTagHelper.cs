namespace SandboxCore11.TagHelpers
{
    using System;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("span", Attributes = "last-updated")]
    public class LastUpdatedTagHelper : TagHelper
    {
        public DateTime LastUpdated { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(LastUpdated < DateTime.Now.AddDays(-3))
            {
                output.Attributes.SetAttribute("class", "text-danger pull-right");
            }
        }
    }
}
