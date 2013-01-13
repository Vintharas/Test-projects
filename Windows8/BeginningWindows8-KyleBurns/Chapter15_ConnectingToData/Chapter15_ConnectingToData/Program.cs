using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter15_ConnectingToData
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ODataDemo.DemoService(
                new Uri("http://services.odata.org/OData/OData.svc"));
            service.Products.ToList().ForEach(p => Console.WriteLine("{0} - {1}", p.Name, p.Price));
            Console.ReadLine();
        }
    }
}
