using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportStore.WebUI.HtmlHelpers;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.UnitTests.HtmlHelpers
{
    [TestClass]
    public class PagingHelpersTest
    {

        [TestMethod]
        public void PageLinks_WhenGivenAPagingInformation_ShouldReturnASeriesOfHtmlLinksForEveryPage()
        {
            // Arrange
            HtmlHelper helper = null;
            PagingInfo pagingInfo = new PagingInfo
                                        {
                                            CurrentPage = 2,
                                            TotalItems = 28,
                                            ItemsPerPage = 10
                                        };
            Func<int, string> pageUrlDelegate = x => "Page" + x;
            // Act
            MvcHtmlString links = helper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(expected: links.ToString(),
            actual: @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");

        }
         
    }
}