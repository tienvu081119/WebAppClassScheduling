using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{

    //Dispose
    //Khá quan trọng
    public class SiteProvider : IDisposable
    {
        public SiteProvider(IConfiguration configuration)
        {
            Console.WriteLine("************************");
            Console.WriteLine("Stite Provider Start");
            Console.WriteLine($"Connection String: { configuration.GetConnectionString("CS")}");
        }

        public void DoSomeThing()
        {
            Console.WriteLine("Do Something ******************");
        }

        public void Dispose()
        {
            Console.WriteLine("************************");
            Console.WriteLine("site Provider Auto Disposable");
        }
    }
}
