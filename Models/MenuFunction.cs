using System;
using System.Linq;
using BlogsConsole.Models;

namespace BlogsConsole
{
    public class MenuFunction
    {
        public static void DisplayAllBlogs()
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

        public static void AddNewBlog()
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

    }
}
