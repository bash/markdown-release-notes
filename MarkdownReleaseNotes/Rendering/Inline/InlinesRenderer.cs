using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownReleaseNotes.Rendering.Inline
{
    internal sealed class InlinesRenderer : IInlinesRenderer
    {
        private readonly IInlineRenderer _inlineRenderer;

        public InlinesRenderer(IInlineRenderer inlineRenderer)
        {
            _inlineRenderer = inlineRenderer;
        }

        public string RenderInlines(IEnumerable<MarkdownInline> inlines)
            => string.Join(string.Empty, inlines.Select(RenderInline));

        private string RenderInline(MarkdownInline inline)
            => _inlineRenderer.Render(inline, RenderInlines);
    }
}
