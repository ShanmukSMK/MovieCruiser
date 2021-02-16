using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Dao;
namespace MovieCruiser
{
    class Program
    {
        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(25, 1);

            try
            {
                List<Movie> movieList = new List<Movie>();
                

                Admin admin = new Admin();
                Customer customer = new Customer();

                Dictionary<int, Customer> customerlist = new Dictionary<int, Customer>()
            {
                {1,new Customer(1,"Kiran") },
                {2,new Customer(2,"Sagar") },
                {3,new Customer(3,"Ashwin") },

            };
                //Favourites List
                List<Movie> favourites = new List<Movie>();
                favourites.Add(new Movie(1, "Avatar", "$2,787,965,087", "Yes", "15/03/2017", "Science Fiction", "Yes"));
                favourites.Add(new Movie(2, "The Avengers", "$1,158,234,345", "Yes", "21/12/2017", "SuperHero", "No"));

                Console.WriteLine("-----MovieCruiser-----");
                Console.WriteLine("   ");
                Console.WriteLine("Admin or Customer\nEnter 1 if you are customer,Enter 2 if you are Admin");
                int user = Convert.ToInt32(Console.ReadLine());

                if (user == 1)
                {
                    Console.WriteLine("Enter Customer Id");
                    customer.CustomerId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Customer Name");
                    customer.CustomerName = Console.ReadLine();
                    if (customer.CustomerId == customerlist[customer.CustomerId].CustomerId && customer.CustomerName == customerlist[customer.CustomerId].CustomerName)
                    {
                        Console.WriteLine("Logged in as " + customer.CustomerName);
                        Console.WriteLine(customer.CustomerName + " MovieList");
                        customer.DisplayCustomerMovieList();
                        int flag = 1;
                        while (flag == 1)
                        {

                            Console.WriteLine("Enter 1 to ViewFavourites\nEnter 2 to Add Movie To Favourites\nEnter 3 to Remove Movie from favourites\nEnter 0 to exit");
                            int customerChoice = Convert.ToInt32(Console.ReadLine());
                            //}
                            if (customerChoice == 1)
                            {

                                Console.WriteLine("Favourite Movies");
                                customer.GetFavaoriteMovieList(favourites);
                            }

                            else if (customerChoice == 2)
                            {
                                Console.WriteLine("Enter the movie to be added to favourites");
                                int favMovieId = Convert.ToInt32(Console.ReadLine());
                                customer.AddMovieToFavorites(favMovieId, favourites);
                                customer.GetFavaoriteMovieList(favourites);
                            }
                            else if (customerChoice == 3)
                            {
                                Console.WriteLine("Enter the movie to be removed from favourites");
                                int movieId = Convert.ToInt32(Console.ReadLine());
                                customer.RemoveMovieFromFavourites(movieId, favourites);
                                customer.GetFavaoriteMovieList(favourites);
                            }
                            else
                            {
                                flag = 0;
                                Console.Write("Enter correct choice");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter valid credentials");
                        
                    }

                }
                else if (user == 2)
                {
                    Console.WriteLine("Enter Admin Id");
                    admin.AdminId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Admin Name");
                    admin.AdminName = Console.ReadLine();
                    if (admin.AdminName == "Shanmuk" && admin.AdminId == 1)
                    {
                        Console.WriteLine(admin.AdminName + "  MovieList");
                        admin.DisplayAdminMovieList();
                        Console.WriteLine("Enter 1 to edit movie");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("Enter the movie to be edit");
                            //int movieId = Convert.ToInt32(Console.ReadLine());
                            string title =Console.ReadLine();
                            admin.EditMovie(title);
                            admin.DisplayAdminMovieList();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter valid credentials");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            }
        }

       

    }

