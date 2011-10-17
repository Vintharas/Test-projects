using System;
using System.Text;
using System.Web.Mvc;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
         public static MvcHtmlString PageLinks(this HtmlHelper html, 
                                               PagingInfo pagingInfo,
                                               Func<int, string> pageUrl) // function that takes an int argument and returns a string
         {
             StringBuilder sb = new StringBuilder();
             for (int i = 1; i <= pagingInfo.TotalPages; i++)
             {
                 TagBuilder tag = new TagBuilder("a"); // construct <a> tag
                 tag.MergeAttribute("href", pageUrl(i));
                 tag.InnerHtml = i.ToString();
                 if (i == pagingInfo.CurrentPage)
                     tag.AddCssClass("selected");
                 sb.Append(tag.ToString());
             }
             return MvcHtmlString.Create(sb.ToString());
         }
    }
}