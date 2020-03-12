using System;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownReleaseNotes.Rendering.Inline
{
    internal sealed class InlineRendererFacade : IInlineRenderer
    {
        public string Render(MarkdownInline inline, RenderChildren renderChildren)
            => inline switch
            {
                CodeInline code => code.Text,
                TextRunInline text => text.Text,
                ItalicTextInline italic => renderChildren(italic.Inlines),
                BoldTextInline bold => renderChildren(bold.Inlines),
                _ => throw new NotImplementedException(),
            };
    }
}
