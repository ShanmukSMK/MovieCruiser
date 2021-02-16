using Com.Cognizant.MovieCruiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Cognizant.MovieCruiser.Dao
{

    abstract public class User
    {
        abstract public List<Movie> GetMovieList();
        public List<Movie> movieList = new List<Movie>()
        {
         new Movie(1, "Avatar", "$2,787,965,087", "Yes", "15/03/2017", "ScienceFiction", "Yes"),
         new Movie(2, "The Avengers", "$1,518,965,087", "Yes", "23/12/2017", "SuperHero", "No"),
         new Movie(3, "Titanic", "$2,187,585,187", "Yes", "21/08/2017", "Romance", "No"),
         new Movie(4, "Jurassic World", "$1,167,100,087", "No", "02/07/2017", "ScienceFiction", "Yes"),
         new Movie(5, "Avengers:End Game", "$2,750,760,087", "Yes", "02/11/2022", "SuperHero", "Yes")
            };
    }
    //Admin Class
    public class Admin : User
    {
        int adminId;
        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }
        string adminName;
        public string AdminName
        {
            get { return adminName; }
            set { adminName = value; }
        }

        //public new List<Movie> movieList;
        public override List<Movie> GetMovieList()
        {

            return movieList;

        }

        public void DisplayAdminMovieList()
        {
            List<Movie> movieList = new List<Movie>();
            
            movieList = GetMovieList();
            Console.WriteLine("MovieId    Title                 BoxOffice            Active           DateofLaunch         Genre          HasTeaser ");
            foreach (Movie temp in movieList)
            {
                Console.WriteLine("{0,-8}  {1,-18}     {2,-15}    {3,-14}   {4,-15}     {5,-15}   {6}", temp.Id, temp.Title, temp.BoxOffice, temp.Active, temp.DateOfLaunch, temp.Genre, temp.HasTeaser);
            }

        }
        //Edit the movie
        public void EditMovie(string title)
        {
            movieList = GetMovieList();
            foreach (Movie temp in movieList)
            {
                if (temp.Title == title)
                {
                    Console.WriteLine("Edit Title");
                    temp.Title = Console.ReadLine();
                    Console.WriteLine("Edit BoxOffice");
                    temp.BoxOffice = Console.ReadLine();
                    Console.WriteLine("Active");
                    temp.Active = Console.ReadLine();
                    Console.WriteLine("Edit DateofLaunch ");
                    temp.DateOfLaunch = Console.ReadLine();
                    Console.WriteLine("Edit Genre");
                    temp.Genre = Console.ReadLine();
                    Console.WriteLine("Has Teaser");
                    temp.HasTeaser = Console.ReadLine();
                    Console.WriteLine("Movie Edited Successfully");

                }

            }
        }


    }
    //Customer Class
    public class Customer : User
    {
        //public new List<Movie> movieList;

        public override List<Movie> GetMovieList()
        {
            return movieList;

        }
        int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public  Customer() { }

        public  Customer(int CustomerId,string CustomerName)
        {
           this.CustomerId = CustomerId;
           this.CustomerName = CustomerName;
        }
        //Display Customer Movies
        public void DisplayCustomerMovieList()
        {
            
            movieList = GetMovieList();
            Console.WriteLine("MovieId    Title                   BoxOffice             Genre          HasTeaser ");
            foreach (Movie temp in movieList)
            {
                Console.WriteLine("{0,-8}  {1,-18}     {2,-15}    {3,-18}   {4}", temp.Id, temp.Title, temp.BoxOffice, temp.Genre, temp.HasTeaser);
            }

        }

            //View Favourites
            public void GetFavaoriteMovieList(List<Movie> favourites)
            {
                Console.WriteLine("MovieID     Title              BoxOffice            Genre");
                foreach (Movie temp in favourites)
                {

                    Console.WriteLine("{0,-8}  {1,-15}    {2,-6}          {3,-14} ", temp.Id, temp.Title, temp.BoxOffice, temp.Genre);
                }
            }


            //Add to favourites
            public void AddMovieToFavorites(int movieId, List<Movie> favourites)
            {
            
                movieList = GetMovieList();
                favourites.Add(movieList[movieId-1]);
                Console.WriteLine("Movie Added to favourites");
            }



            //Remove Favourites
            public void RemoveMovieFromFavourites(int movieId, List<Movie> favourites)
            {
                favourites.RemoveAt(movieId-1);
                Console.WriteLine("Movie Removed from favourites");


            }



        }
    } 
