using System;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Dao;
using System.Collections.Generic;

namespace project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(12, 2);

                List<Movie> movies = new List<Movie>();

                List<Movie> favouriteMovieList = new List<Movie>()
            {
               new Movie(1,"Avatar","$2787965087","true","15/03/2017","Science Fiction","false"),
               new Movie(2,"The Avengers","$1518812988","true","23/12/2017","Superhero","false"),
               new Movie(3,"Titanic","$2187463944","true","21/08/2017","Romance","false")
            };

                Admin admin = new Admin();
                Customer customer = new Customer();
                Dictionary<int, Customer> customerlist = new Dictionary<int, Customer>()
            {
                {1,new Customer(1,"Aravind") },
                {2,new Customer(2,"Vishnu") },
                {3,new Customer(3,"Rajesh") },
            };
            login:
                Console.WriteLine("Enter 1 to login as admin other number to login as customer");
                int i = Convert.ToByte(Console.ReadLine());
                if (i == 1)
                {
                adminLogin:
                    Console.WriteLine("Enter Id of admin");
                    admin.AdminId = Console.ReadLine();
                    Console.WriteLine("Enter name of admin");
                    admin.AdminName = Console.ReadLine();
                    if ((admin.AdminId == "Aravind") && (admin.AdminName == "Sikha"))
                    {
                        Console.WriteLine("Admin Sucessfully Loged In ");
                    adminOptions:
                        Console.WriteLine("Enter 1 to view movielist ,2 to edit movie,3 to change usertype and 0 to Exit");
                        int j = Convert.ToByte(Console.ReadLine());
                        if (j == 3)
                        {
                            goto login;
                        }
                        if (j == 1)
                        {
                            admin.DisplayAdminMovieList();
                        }
                        if (j == 2)
                        {
                            Console.WriteLine("Enter the Id to Edit Movie details");
                            int c = Convert.ToByte(Console.ReadLine());
                            admin.EditMovie(c);
                            Console.WriteLine("Movie Record Edited succesfully");
                        }
                        if (j == 0)
                        {
                            Environment.Exit(1);
                        }
                        goto adminOptions;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials");
                        goto adminLogin;
                    }
                }
                else
                {
                    goto customer;
                }
            customer:
                Console.WriteLine("Enter username of customer");
                customer.CustomerId = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Enter name of customer");
                customer.CustomerName = Console.ReadLine();
                if (customer.CustomerId == customerlist[customer.CustomerId].CustomerId && customer.CustomerName == customerlist[customer.CustomerId].CustomerName)
                {
                    Console.WriteLine("Customer login successfully");
                    Console.WriteLine("MovieList is \n");
                    customer.DisplayCustomerMovieList();
                    List<Movie> favourites = new List<Movie>();
                    favourites.Add(new Movie(1, "Avatar", "$2,787,965,087", "Yes", "15/03/2017", "Science Fiction", "Yes"));
                    Console.WriteLine("Enter an id from movielist to add to favorites");
                    int n = Convert.ToByte(Console.ReadLine());
                    if (n > 3)
                    {
                        Console.WriteLine("MovieId is not in the list");
                    }
                    else
                        customer.AddToFavourites(n, movies, favourites);
                    Console.WriteLine("Enter the Id to delete the wanted Movie from Favourites");
                    int p = Convert.ToInt16(Console.ReadLine());
                    customer.RemoveFavourites(p, favourites);
                }
                else
                    Console.WriteLine("Invalid Customer credentials");

            }
            catch(Exception ex)
            {
                Console.WriteLine("The System Returned an Exceptipon");

            }
           
        }

    }
}

