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
                    Console.WriteLine("1) Display all blogs");
                    Console.WriteLine("2) Add a blog");
                    Console.WriteLine("3) Create a post");

                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        MenuFunction.DisplayAllBlogs();
                    }

                    if (choice == "2")
                    {
                        MenuFunction.AddNewBlog();
                    }
                    if (choice == "3")
                    {
                        //select which blog to post to
                            //list all blogs
                            //get user input
                            //set BlogId FK
                            //commit post to proper blog
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
