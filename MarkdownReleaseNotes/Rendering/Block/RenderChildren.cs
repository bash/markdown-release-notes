using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal delegate string RenderChildren(IEnumerable<MarkdownBlock> blocks);
}
