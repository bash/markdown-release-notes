using System;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal class BlockRendererFacade : IBlockRenderer
    {
        private readonly IBlockRenderer<ListBlock> _listRenderer;

        private readonly IBlockRenderer<ParagraphBlock> _paragraphRenderer;

        public BlockRendererFacade(
            IBlockRenderer<ListBlock> listRenderer,
            IBlockRenderer<ParagraphBlock> paragraphRenderer)
        {
            _listRenderer = listRenderer;
            _paragraphRenderer = paragraphRenderer;
        }

        public string Render(MarkdownBlock block, RenderChildren renderChildren)
            => block switch
            {
                ListBlock list => _listRenderer.Render(list, renderChildren),
                ParagraphBlock paragraph => _paragraphRenderer.Render(paragraph, renderChildren),
                _ => throw new NotImplementedException(),
            };
    }
}
