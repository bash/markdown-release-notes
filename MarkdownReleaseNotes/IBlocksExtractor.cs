using System.Collections.Generic;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes
{
    internal interface IBlocksExtractor
    {
        public IEnumerable<MarkdownBlock> ExtractBlocks(IEnumerable<MarkdownBlock> blocks, string version);
    }
}
