using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieAppLibrary.GlobalException;

namespace MovieAppLibrary
{
   
        public class MovieManager
        {
            public static List<Movie> movies = new List<Movie>();

            Movie movie = new Movie();

            public MovieManager()
            {
            movies = DeserializSerializ.DeserializeData();
           
            }

            public void MainMenu(int userInput)
            {
            

            switch (userInput)
                {
                    case 1:
                        AddMovie();
                        DeserializSerializ.SerializeData(movies);
                        break;
                        
                    case 2:
                        DisplayMovie(movies);
                        DeserializSerializ.SerializeData(movies);
                        break;

                    case 3:
                        DeleteMovie(movies);
                        DeserializSerializ.SerializeData(movies);
                        break;
 
                    case 4:
                        Environment.Exit(0);
                        break;
                        
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }


        }

            public void AddMovie()
            {
            try
            {
                if (movies.Count < 3)
                {
                    Console.WriteLine("Enter the name of movie : ");
                    string movieName = Console.ReadLine();

                    Console.WriteLine("Enter the genre of movie : ");
                    string movieGenre = Console.ReadLine();

                    Console.WriteLine("Enter the year of release of movie : ");
                    int yrOfRelease = int.Parse(Console.ReadLine());

                    string movieId = CreateMovieId(movieName, movieGenre, yrOfRelease);


                    Movie movie1 = new Movie(movieId, movieName, movieGenre, yrOfRelease);

                    movies.Add(movie1);
                }
                else
                {
                    throw new CapacityFull("Capacity of movie store is full");

                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
                
            }

            public string CreateMovieId(string movieName, string movieGenre, int yrOfRelease)
            {
                string yrOfReleaseStr = yrOfRelease.ToString();
                string stringId = movieName.Substring(0, 2) + movieGenre.Substring(0, 2) + yrOfReleaseStr.Substring(2, 2);
                return stringId;
            }

        
        
        public void DisplayMovie(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies to display.");
                return;
            }

            int idWidth = 10;
            int nameWidth = 30;
            int genreWidth = 15;
            int yearWidth = 15;

            Console.WriteLine("+" + new string('-', idWidth) + "+" + new string('-', nameWidth) + "+" + new string('-', genreWidth) + "+" + new string('-', yearWidth) + "+");
            Console.WriteLine("| {0,-" + idWidth + "} | {1,-" + nameWidth + "} | {2,-" + genreWidth + "} | {3,-" + yearWidth + "} |",
                              "Movie ID", "Movie Name", "Genre", "Year of Release");
            Console.WriteLine("+" + new string('-', idWidth) + "+" + new string('-', nameWidth) + "+" + new string('-', genreWidth) + "+" + new string('-', yearWidth) + "+");  // Separator line

            foreach (Movie movie in movies)
            {
                Console.WriteLine("| {0,-" + idWidth + "} | {1,-" + nameWidth + "} | {2,-" + genreWidth + "} | {3,-" + yearWidth + "} |",
                                  movie.MovieId,
                                  movie.MovieName,
                                  movie.Genre,
                                  movie.YearOfRelease);
            }

            Console.WriteLine("+" + new string('-', idWidth) + "+" + new string('-', nameWidth) + "+" + new string('-', genreWidth) + "+" + new string('-', yearWidth) + "+");
        }



        public void DeleteMovie(List<Movie> movies)
            {
            try
            {
                if (movies.Count != 0)
                {
                    Console.WriteLine("Enter the ID of movie : ");
                    string input = Console.ReadLine();

                    int indexToRemove = -1;
                    for (int i = 0; i < movies.Count; i++)
                    {
                        if (movies[i].MovieId == input)
                        {
                            indexToRemove = i;
                            break;
                        }
                    }

                    if (indexToRemove != -1)
                    {
                        movies.RemoveAt(indexToRemove);
                        Console.WriteLine("Movie deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Movie not found.");
                    }

                }
                else
                {
                    throw new MovieStoreEmpty("Movie store is empty");
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
                
            }


        }
    
}
