using MarkdownReleaseNotes.Rendering.Inline;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal class ParagraphRenderer : IBlockRenderer<ParagraphBlock>
    {
        private readonly IInlinesRenderer _inlinesRenderer;

        public ParagraphRenderer(IInlinesRenderer inlinesRenderer)
        {
            _inlinesRenderer = inlinesRenderer;
        }

        public string Render(ParagraphBlock block, RenderChildren renderChildren)
            => _inlinesRenderer.RenderInlines(block.Inlines);
    }
}
