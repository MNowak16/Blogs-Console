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

        public static void DisplayAllBlogsWithIDs()
        {
            var db = new BloggingContext();
            var query = db.Blogs.OrderBy(b => b.BlogId);

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine("{0}) {1}", item.BlogId, item.Name);
            }
        }

        public static string AddNewBlog()
        {
            // Create and save a new Blog
            Console.Write("Enter a name for a new Blog: ");
            var name = Console.ReadLine();

            var blog = new Blog { Name = name };

            var db = new BloggingContext();
            db.Blogs.Add(blog);
            //save changes is the commit to the database
            db.SaveChanges();
            return name;
        }

        public static string AddNewPost()
        {
            //list all blogs
            Console.WriteLine("Select which blog you would like to post to:");
            {
                DisplayAllBlogsWithIDs();
            }
            var id = Console.ReadLine();

            Console.WriteLine("Enter a title for the post:");
            var postTitle = Console.ReadLine();
            Console.WriteLine("Enter the content of the post:");
            var postContent = Console.ReadLine();

            var db = new BloggingContext();
            var post = new Post
            {
                Title = postTitle,
                Content = postContent,
                BlogId = Convert.ToInt32(id)
            };
            db.Posts.Add(post);
            db.SaveChanges();
            return postTitle;
        }
    }
}
