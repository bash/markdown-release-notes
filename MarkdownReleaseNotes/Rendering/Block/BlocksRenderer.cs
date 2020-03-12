using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal class BlocksRenderer : IBlocksRenderer
    {
        private static readonly string BlockSeparator = Environment.NewLine + Environment.NewLine;

        private readonly IBlockRenderer _blockRenderer;

        public BlocksRenderer(IBlockRenderer blockRenderer)
        {
            _blockRenderer = blockRenderer;
        }

        public string RenderBlocks(IEnumerable<MarkdownBlock> blocks)
            => string.Join(BlockSeparator, blocks.Select(RenderBlock));

        private string RenderBlock(MarkdownBlock block)
            => _blockRenderer.Render(block, RenderBlocks);
    }
}
