using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal interface IBlockRenderer<in TBlock>
        where TBlock : MarkdownBlock
    {
        public string Render(TBlock block, RenderChildren renderChildren);
    }
}
