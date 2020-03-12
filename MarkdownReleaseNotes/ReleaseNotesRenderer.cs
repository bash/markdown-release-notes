using MarkdownReleaseNotes.Rendering.Block;
using MarkdownReleaseNotes.Rendering.Inline;
using Microsoft.Toolkit.Parsers.Markdown;

namespace MarkdownReleaseNotes
{
    public static class ReleaseNotesRenderer
    {
        private delegate string GetBulletPoint(int index);

        public static string RenderReleaseNotes(string markdown, string version)
        {
            var document = ParseMarkdown(markdown);
            var blocks = CreateBlocksExtractor().ExtractBlocks(document.Blocks, version);
            return CreateBlocksRenderer().RenderBlocks(blocks);
        }

        private static IBlocksRenderer CreateBlocksRenderer()
        {
            var inlinesRenderer = CreateInlinesRenderer();
            return new BlocksRenderer(
                new BlockRendererFacade(
                    new ListRenderer(),
                    new ParagraphRenderer(inlinesRenderer)));
        }

        private static IInlinesRenderer CreateInlinesRenderer()
            => new InlinesRenderer(new InlineRendererFacade());

        private static IBlocksExtractor CreateBlocksExtractor()
            => new BlocksExtractor(CreateInlinesRenderer());

        private static MarkdownDocument ParseMarkdown(string markdown)
        {
            var document = new MarkdownDocument();
            document.Parse(markdown);
            return document;
        }
    }
}
