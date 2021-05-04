using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.BlogServiceClient client = new ServiceReference.BlogServiceClient();
            Stream stream = client.DownloadFileTest();
          
            using (var filestream = File.Create("resume.docx"))
            {
             
                stream.CopyTo(filestream);
            Console.WriteLine(filestream.Length);
            }
            Console.WriteLine("Copied");
            Console.ReadLine();
        }
    }
}
