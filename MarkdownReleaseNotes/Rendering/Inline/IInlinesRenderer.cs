using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownReleaseNotes.Rendering.Inline
{
    internal interface IInlinesRenderer
    {
        public string RenderInlines(IEnumerable<MarkdownInline> inlines);
    }
}
