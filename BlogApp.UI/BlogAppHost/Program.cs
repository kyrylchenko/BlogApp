using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BLL.Services;
namespace BlogAppHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(BlogService));
            host.Open();
            Console.WriteLine("Host Opened");

            Console.ReadLine();

        }
    }
}
