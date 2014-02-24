using EFCodeFirst_Chapter2.Domain;
using EFCodeFirst_Chapter2.Storage;
using NUnit.Framework;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EFCodeFirst_Chapter2.Tests.Domain
{
    [TestFixture]
    public class ClerkTests
    {
         [TearDown]
         public void TearDown()
         {
            // Cleaning database
             using (var context = new BreakAwayContext())
             {
                 var allDestinations = context.Destinations.ToList();
                 foreach (var destination in allDestinations)
                 {
                     context.Destinations.Remove(destination);
                 }
                 context.SaveChanges();

             }
         }

         [Test]
         public void InsertDestination_WhenClerkInsertsADestination_ShouldBeStoredInTheDatabase()
         {
             // Arrange
             var destination = new Destination
                                   {
                                       Country = "Indonesia",
                                       Description = "EcoTourism at its best in exquisite Bali",
                                       Name = "Bali"
                                   };
             var theClerk = new Clerk();
             // Act
             theClerk.InsertsDestination(destination);
             // Assert
             Destination actualDestination = null;
             using (var context = new BreakAwayContext())
             {
                 actualDestination = context.Destinations.Where(x => x.Country == "Indonesia").FirstOrDefault();
             }
             Assert.AreEqual(expected: destination, actual: actualDestination);
         }
    }
}