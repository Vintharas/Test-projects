using EFCodeFirst_Chapter2.Storage;

namespace EFCodeFirst_Chapter2.Domain
{
    public class Clerk
    {
        public void InsertsDestination(Destination destination)
        {
            using (var context = new BreakAwayContext())
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
            }
        }
    }
}