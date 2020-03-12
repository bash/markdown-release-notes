using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal interface IBlocksRenderer
    {
        public string RenderBlocks(IEnumerable<MarkdownBlock> blocks);
    }
}
