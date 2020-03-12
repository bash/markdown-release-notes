using System;
using System.Collections.Generic;
using System.Linq;
using MarkdownReleaseNotes.Rendering.Inline;
using Messerli.Utility.Extension;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes
{
    internal sealed class BlocksExtractor : IBlocksExtractor
    {
        private readonly IInlinesRenderer _inlinesRenderer;

        public BlocksExtractor(IInlinesRenderer inlinesRenderer)
        {
            _inlinesRenderer = inlinesRenderer;
        }

        public IEnumerable<MarkdownBlock> ExtractBlocks(IEnumerable<MarkdownBlock> blocks, string version)
        {
            var headerIndex = FindHeaderIndexForVersionWrapped(blocks, version);
            var blocksAfterHeader = GetBlocksAfterHeader(blocks, headerIndex);
            return GetBlocksUntilNextHeader(blocksAfterHeader);
        }

        private static IEnumerable<MarkdownBlock> GetBlocksAfterHeader(IEnumerable<MarkdownBlock> blocks, int headerIndex)
            => blocks.Skip(headerIndex + 1);

        private static IEnumerable<MarkdownBlock> GetBlocksUntilNextHeader(IEnumerable<MarkdownBlock> blocks)
            => blocks.TakeWhile(block => !(block is HeaderBlock));

        private int FindHeaderIndexForVersionWrapped(IEnumerable<MarkdownBlock> blocks, string version)
        {
            try
            {
                return FindHeaderIndexForVersion(blocks, version);
            }
            catch (InvalidOperationException exception)
            {
                throw new ReleaseNotesException($"Version {version} is missing from changelog", exception);
            }
        }

        private int FindHeaderIndexForVersion(IEnumerable<MarkdownBlock> blocks, string version)
            => blocks
                .WithIndex()
                .First(block => IsVersionSectionHeader(block.Value, version))
                .Index;

        private bool IsVersionSectionHeader(MarkdownBlock block, string version)
            => block is HeaderBlock header
               && IsSectionHeader(header)
               && HeaderMatchesVersion(header, version);

        private static bool IsSectionHeader(HeaderBlock header)
        {
            const int sectionHeaderLevel = 2;
            return header.HeaderLevel == sectionHeaderLevel;
        }

        private bool HeaderMatchesVersion(HeaderBlock header, string version)
            => RenderHeader(header) == version;

        private string RenderHeader(HeaderBlock header)
            => _inlinesRenderer.RenderInlines(header.Inlines).Trim();
    }
}
