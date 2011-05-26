using System.Collections.Generic;
using System.Web.WebPages;
using System;

namespace RazorExtensions
{
    public static class RazorExtensions
    {
        public static HelperResult List<T>(this IEnumerable<T> items, Func<T, HelperResult> template)
        {
            return new HelperResult(writer =>
            {
                foreach (var item in items)
                {
                    template(item).WriteTo(writer);
                }
            });
        }

        private static readonly object DefaultObject = new object();

        public static HelperResult RenderSection(this WebPageBase page, string sectionName, Func<object, HelperResult> defaultContent)
        {
            return page.IsSectionDefined(sectionName) ? page.RenderSection(sectionName) : defaultContent(DefaultObject);
        }
    }
}
