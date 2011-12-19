using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TestingEFCodeFirst.Model;
using TestingEFCodeFirst.Storage;

namespace TestingEFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebsiteContext>());
                using (var context = new WebsiteContext())
                {
                    context.Pages.Add(new Page {Title = "Awesomeeee"});
                    context.SaveChanges();
                    Console.WriteLine("saved something in the database, isn't that awesome!");
                    var Pages = context.Pages.ToList();
                    foreach (var page in Pages)
                    {
                        Console.WriteLine("This is a page in the database: {0}", page.Title);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
