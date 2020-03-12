using Microsoft.Toolkit.Parsers.Markdown.Inlines;

namespace MarkdownReleaseNotes.Rendering.Inline
{
    internal interface IInlineRenderer<in TInline>
        where TInline : MarkdownInline
    {
        public string Render(TInline inline, RenderChildren renderChildren);
    }
}
