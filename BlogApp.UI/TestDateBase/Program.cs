using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDateBase
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService service = new UserService();
            // UserRepository userRepository = new UserRepository(new BlogContext());
            //IEnumerable<User> users = userRepository.GetAll();

            //User user = userRepository.GetAll().FirstOrDefault(u => u.MyArticles.Count == 0);
            //Console.WriteLine(user.MyArticles.Count);
            //user.MyArticles.Add(new Article() { Title = "hjk", FilePath = "dssdf" });
            //UserService.SaveChanges();
            //Console.WriteLine(user.MyArticles.Count);

            //UserDTO user = service.GetAll().FirstOrDefault(u => u.MyArticles.Count == 0);
            //Console.WriteLine(user.MyArticles.Count);
            //user.MyArticles.Add(new ArticleDTO() { Title = "test", FilePath = "asas" });
            //service.CreateOrUpdate(user);
            //user = service.Get(user.UserId);
            //Console.WriteLine(user.MyArticles.Count);
            //foreach (var u in service.GetAll())
            //    Console.WriteLine($"{u.Name}  {u.MyArticles.Count}");
            ServiceReference.BlogServiceClient c = new ServiceReference.BlogServiceClient();
            // c.RegisterUser(new UserDTO() { Name = "111", Login = "1114", Password = "1115" });

           c.Connect("123", "123");
            c.UploadFile("123.rar", File.OpenRead("lol.rar"));
           using (var s = File.Create("123povezlo"))
            {
                c.DownloadFile("123.rar").CopyTo(s);
            }
           // Console.WriteLine(c.GetLikedArticles().Count);
           // List<ArticleDTO> articles = c.GetLikedArticles();
           // articles.Clear();
           // c.SetLikedArticles(articles);
           // Console.WriteLine(c.GetLikedArticles().Count);
            Console.WriteLine("ok");
            Console.ReadLine();
        }
    }
}
