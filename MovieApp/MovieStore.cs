using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using MovieAppLibrary;

namespace MoviesApp
{
    public class MovieStore 
    {
       
        MovieManager movieManager = new MovieManager();

        public MovieStore() 
        {
           
            MoviesMenu(); 
        }


        public void MoviesMenu()
        {
            Console.WriteLine("Welcome to movie store .");
            Console.WriteLine();
            Console.WriteLine();

            char choice = 'y';

           do
            {
                Console.WriteLine("Total available movies : " + MovieManager.movies.Count);
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Display Movie");
                Console.WriteLine("3. Delete Movie");
                Console.WriteLine("4. Exit ");
                Console.WriteLine("Enter you choice : ");
                int inputNum = int.Parse(Console.ReadLine());
                movieManager.MainMenu(inputNum);
                Console.WriteLine();
                Console.WriteLine("Do you want to continue Y/N ?");
                choice = char.Parse(Console.ReadLine());
            } while (choice == 'Y' || choice == 'y') ;


        }


        
    }
}
