using System;
using System.Collections.Generic;
using System.Linq;
using Messerli.Utility.Extension;
using Microsoft.Toolkit.Parsers.Markdown;
using Microsoft.Toolkit.Parsers.Markdown.Blocks;

namespace MarkdownReleaseNotes.Rendering.Block
{
    internal sealed class ListRenderer : IBlockRenderer<ListBlock>
    {
        private delegate string GetBulletPoint(int index);

        public string Render(ListBlock list, RenderChildren renderChildren)
            => string.Join(Environment.NewLine, RenderListItems(list, renderChildren));

        private static IEnumerable<string> RenderListItems(ListBlock list, RenderChildren renderChildren)
            => list.Items
                .WithIndex()
                .Select(CurryRenderListItem(CurryGetBulletPoint(list.Style), renderChildren));

        private static Func<(ListItemBlock Value, int Index), string> CurryRenderListItem(
            GetBulletPoint getBulletPoint,
            RenderChildren renderChildren)
            => item => getBulletPoint(item.Index) + renderChildren(item.Value.Blocks);

        private static GetBulletPoint CurryGetBulletPoint(ListStyle style)
            => style switch
            {
                ListStyle.Bulleted => index => "• ",
                ListStyle.Numbered => index => $"{index + 1}. ",
                _ => throw new InvalidOperationException(),
            };
    }
}
