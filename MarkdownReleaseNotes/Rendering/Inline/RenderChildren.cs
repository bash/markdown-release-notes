using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownReleaseNotes.Rendering.Inline
{
    internal delegate string RenderChildren(IEnumerable<MarkdownInline> inlines);
}
