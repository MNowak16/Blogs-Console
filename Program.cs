using NLog;
using BlogsConsole.Models;
using System;
using System.Linq;

namespace BlogsConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            logger.Info("Program started");
            try
            {
                var choice = "";

                do
                {
                    Console.WriteLine("1) Display all blogs");
                    Console.WriteLine("2) Add a blog");
                    Console.WriteLine("3) Create a post");

                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        // Display all Blogs from the database
                        var db = new BloggingContext();
                        var query = db.Blogs.OrderBy(b => b.Name);

                        Console.WriteLine("All blogs in the database:");
                        foreach (var item in query)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                    if (choice == "2")
                    {
                        // Create and save a new Blog
                        Console.Write("Enter a name for a new Blog: ");
                        var name = Console.ReadLine();

                        var blog = new Blog { Name = name };

                        var db = new BloggingContext();
                        db.Blogs.Add(blog);
                        //save changes is the commit to the database
                        db.SaveChanges();
                        logger.Info("Blog added - {name}", name);
                    }
                    if (choice == "3")
                    {

                    }
                }
                while (choice == "1" || choice == "2" || choice == "3");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}
