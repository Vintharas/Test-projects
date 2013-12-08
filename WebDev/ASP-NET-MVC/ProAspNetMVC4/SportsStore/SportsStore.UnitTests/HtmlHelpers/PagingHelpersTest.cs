using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests.HtmlHelpers
{
    [TestClass]
    public class PagingHelpersTest
    {
        [TestMethod]
        public void PageLinks_WhenGivenPagingInformationAndHowToGenerateLinks_ShouldGenerateASeriesOfLinksForAllPages()
        {
            // Arrange
            // In order to test an extension method we need to create a null instance of the class the
            // extension method applies to
            HtmlHelper helper = null;
            PagingInfo pagingInfo = new PagingInfo
                {
                    CurrentPage = 2,
                    TotalItems = 28,
                    ItemsPerPage = 10
                };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = helper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(expected: @"<a href=""Page1"">1</a>" + 
                                      @"<a class=""selected"" href=""Page2"">2</a>" + 
                                      @"<a href=""Page3"">3</a>",
                            actual: result.ToString());
        }
        
    }
}