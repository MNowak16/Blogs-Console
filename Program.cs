﻿using NLog;
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
                    Console.WriteLine("Enter your selection:");
                    Console.WriteLine("1) Display all blogs");
                    Console.WriteLine("2) Add a blog");
                    Console.WriteLine("3) Create a post");
                    Console.WriteLine("4) Display posts");
                    Console.WriteLine("Enter q to quit");

                    choice = Console.ReadLine();

                    if (choice.ToLower() == "q")
                    {
                        logger.Info("Program terminated");
                        break;
                    }

                    if (choice == "1")
                    {
                        logger.Info("Option 1 selected");
                        Console.WriteLine();
                        MenuFunction.DisplayAllBlogs();
                    }

                    if (choice == "2")
                    {
                        logger.Info("Option 2 selected");
                        Console.WriteLine();
                        var name = MenuFunction.AddNewBlog();
                        logger.Info("Blog added - {name}", name);
                    }
                    if (choice == "3")
                    {
                        logger.Info("Option 3 selected");
                        Console.WriteLine();
                        var post = MenuFunction.AddNewPost();
                        logger.Info("Post added - {post}", post);
                    }
                    if (choice == "4")
                    {
                        logger.Info("Option 4 selected");
                        Console.WriteLine();
                        MenuFunction.DisplayAllPostsFromBlog();
                    }
                }
                while (choice == "1" || choice == "2" || choice == "3" || choice == "4");
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}
