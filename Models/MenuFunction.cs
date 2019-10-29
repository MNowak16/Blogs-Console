using System;
using System.Linq;
using BlogsConsole.Models;

namespace BlogsConsole
{
    public class MenuFunction
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void DisplayAllBlogs()
        {
            // Display all Blogs from the database
            var db = new BloggingContext();
            var query = db.Blogs.OrderBy(b => b.Name);

            var bCount = query.Count();

            Console.WriteLine("{0} blog(s) returned", bCount);
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
        }

        public static void DisplayAllBlogsWithIDs()
        {
            var db = new BloggingContext();
            var query = db.Blogs.OrderBy(b => b.BlogId);

            var bCount = query.Count();

            foreach (var item in query)
            {
                Console.WriteLine("{0}) {1}", item.BlogId, item.Name);
            }
        }

        public static void DisplayAllPostsFromBlog()
        {
            // Display all Blogs from the database from a specific blog
            Console.WriteLine("Select the blog's posts to display:");
            MenuFunction.DisplayAllBlogsWithIDs();
            var input = Console.ReadLine();
            
            //query the db where the input = BlogId
            var db = new BloggingContext();
            var query = db.Posts.Where(s => s.BlogId.ToString() == input).OrderBy(s => s.Title);
            var row = db.Blogs.Where(s => s.BlogId.ToString() == input).FirstOrDefault();
            var pCount = query.Count();

            //display all query results
            Console.WriteLine("{0} post(s) from {1}:", pCount, row.Name);
            foreach (var item in query)
            {
                Console.WriteLine(item.Title);
            }
            Console.WriteLine();
        }

        public static string AddNewBlog()
        {
            // Create and save a new Blog
            Console.Write("Enter a name for a new Blog: ");
            var name = Console.ReadLine();
            //check name is not blank
            while (name == "")
            {
                Console.WriteLine("Blog name cannot be null");
                Console.Write("Enter a name for a new Blog: ");
                name = Console.ReadLine();
                logger.Error("Blog name cannot be null");
            }
                    
            var blog = new Blog { Name = name };
            var db = new BloggingContext();
            db.Blogs.Add(blog);
            //save changes is the commit to the database
            db.SaveChanges();
            logger.Info("Blog added - {name}", name);
            return name;
        }

        public static string AddNewPost()
        {
            //list all blogs
            Console.WriteLine("Select which blog you would like to post to:");
            DisplayAllBlogsWithIDs();
            var id = Console.ReadLine();

            //check id is an integer
            int value;
            while (!int.TryParse(id, out value))
            {
                Console.WriteLine("Invalid selection. Please select the blog you would like to post to: ");
                DisplayAllBlogsWithIDs();
                logger.Error("Invalid blog ID");
            }

            //check id is a valid id
            var db2 = new BloggingContext();
            var exists = db2.Blogs.Any(b => b.BlogId == value);
            while (exists == false)
            {
                Console.WriteLine("Invalid ID. Please select the blog you would like to post to: ");
                DisplayAllBlogsWithIDs();
                logger.Error("There are no blogs saved with that ID");
            }
            
            Console.Write("Enter a title for the post: ");
            var postTitle = Console.ReadLine();
            //check post title is not blank
            while (postTitle == "")
            {
                Console.WriteLine("Post title cannot be null");
                Console.Write("Enter a title for the post: ");
                postTitle = Console.ReadLine();
                logger.Error("Post title cannot be null");
            }

            Console.WriteLine("Enter the content of the post:");
            var postContent = Console.ReadLine();
            //check post content is not blank
            while (postContent == "")
            {
                Console.WriteLine("Post content cannot be null");
                Console.WriteLine("Enter the content of the post:");
                postContent = Console.ReadLine();
                logger.Error("Post content cannot be null");
            }

            var db = new BloggingContext();
            var post = new Post
            {
                Title = postTitle,
                Content = postContent,
                BlogId = Convert.ToInt32(id)
            };
            db.Posts.Add(post);
            db.SaveChanges();
            logger.Info("Post added - {post}", post);
            return postTitle;
        }
    }
}
