using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment_05_movie
    {

        class Movie
        {
            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public string Director { get; set; }
            public double ImdbRating { get; set; }
        }

        class MovieManager
        {
            public Movie[] records = new Movie[100];

            public void addMovie(Movie rec)
            {
                for(int i = 0; i <=100; i++)
                {
                    if (records[i] == null)
                    {
                        records[i] = new Movie { MovieId = rec.MovieId, MovieName = rec.MovieName,
                            Director = rec.Director,
                            ImdbRating = rec.ImdbRating
                        };
                        return;
                        //records[i]=new Movie { }
                    }
                }
            }

            public void UpdateMovieDetails(Movie rec)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (records[i] != null && records[i].MovieId == rec.MovieId)
                    {
                        records[i].MovieName = rec.MovieName;
                        records[i].Director = rec.Director;
                        records[i].ImdbRating = rec.ImdbRating;
                        return;
                    }
                }
                throw new Exception("Movie not found to update");
            }
            public Movie FindMovieDetails(int id)
            {
                foreach (Movie item in records)
                {
                    if (item != null && item.MovieId == id)
                        return item;
                }
                throw new Exception("No Account found");

            }
            public void DeleteMovie(int id)
            {
                for (int i = 0; i <100; i++)
                {
                    if (records[i] != null && records[i].MovieId == id)
                    {
                        //.NET does not allow to delete an object. 
                        records[i] = null; //
                        return;
                    }

                }
                throw new Exception("No Account found to delete");

            }



        }

        class UIManager
        {
            public static MovieManager mgr = new MovieManager();

            internal static void DisplayMenu(string file)
            {
                bool processing = true;
                string menu = File.ReadAllText(file);
                do
                {
                    int choice = Utilities.GetNumber(menu);
                    processing = processMenu(choice);
                } while (processing);
                Console.WriteLine("Thanks for using our application");
            }


            private static bool processMenu(int choice)
            {
                switch (choice)
                {
                    case 1:
                        addingHelper();
                        break;
                    case 2:
                        updatingHelper();
                        break;
                    case 3:
                        findingHelper();
                        break;
                    case 4:
                        deleteHelper();
                        break;
                    default:
                        return false;
                }
                return true;//break vs. goto vs. return vs. throw.
            }

            private static void addingHelper()
            {
                int id = Utilities.GetNumber("Enter the ID of the Movie");
                string name = Utilities.Prompt("Enter the Name of the movie");
                string director = Utilities.Prompt("Enter the Name of the Director");
                double rating = Convert.ToDouble(Utilities.Prompt("Enter the Rating"));
                Movie rec = new Movie{ MovieId = id, MovieName = name,Director=director,
                    ImdbRating=rating };
                mgr.addMovie(rec);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            }

            private static void updatingHelper()
            {
                int id = Utilities.GetNumber("Enter the ID of the Movie");
                string name = Utilities.Prompt("Enter the Name of the movie");
                string director = Utilities.Prompt("Enter the Name of the Director");
                double rating = Convert.ToDouble(Utilities.Prompt("Enter the rating of the movie"));
                Movie rec = new Movie
                {
                    MovieId = id,
                    MovieName = name,
                    Director = director,
                    ImdbRating = rating
                };
                mgr.UpdateMovieDetails(rec);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();

            }
            private static void findingHelper()
            {
                int id = Utilities.GetNumber("Enter the ID of the Movie");
              Movie getRecord=  mgr.FindMovieDetails(id);
                Console.WriteLine($"Movie ID: {getRecord.MovieId}");
                Console.WriteLine($"Movie Name: {getRecord.MovieName}");
                Console.WriteLine($"Movie Director: {getRecord.Director}");
                Console.WriteLine($"Movie Rating: {getRecord.ImdbRating}");
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();


            }
            private static void deleteHelper()
            {
                int id = Utilities.GetNumber("Enter the ID of the Movie");
                mgr.DeleteMovie(id);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();

            }

        }


        static void Main(string[] args)
        {
            UIManager.DisplayMenu(args[0]);
        } 
    }
}
