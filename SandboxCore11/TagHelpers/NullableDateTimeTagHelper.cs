namespace SandboxCore11.TagHelpers
{
    using System;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public class NullableDateTimeTagHelper : TagHelper
    {
        public DateTime? Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;

            var content = string.Empty;

            if (Value.HasValue)
            {
                content = Value.Value.ToString("yyyy/MM/dd HH:mm");
            }

            output.Content.SetContent(content);
        }
    }
}
