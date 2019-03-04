using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.JSON;

namespace ToDoList {
    class Movie {
        private string Title;
        public Movie(string title) {
            this.Title = title;
        }

        public static Movie GetTopRatedMovie() {
            string movieName = "";
            List<string> movies;
            Random r = new Random();
            do {
                movies = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KalenGitHub\ToDoList\movies.txt").ToList();

                dynamic response = JsonConvert.DeserializeObject(JSONHelper.GetTopRatedMovies());


                movieName = response.results[r.Next(0, 19)].title;

            } while (movies.Contains(movieName));

            return new Movie(movieName);
        }

        public static Movie GetDisneyMovie() {
            string movieName = "";
            List<string> movies;
            bool movieFound = false;

            do {
                movies = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\KalenGitHub\ToDoList\movies.txt").ToList();

                dynamic retrievedMovies = JsonConvert.DeserializeObject(JSONHelper.GetDisneyMovies());

                for (int i = 0; i < 20; i++) {
                    dynamic retrievedDetails = JSONHelper.GetMovieDetails(Int32.Parse(""+retrievedMovies.results[i].id));

                    List<string> productionCompanies = new List<string>();

                    try {
                        for(int j = 0; j < 5; j++) {
                            productionCompanies.Add(""+retrievedDetails.production_companies[j].name);
                        }
                    } catch { }


                    string s = "" + retrievedDetails.adult;

                    if (productionCompanies.Contains("Walt Disney Pictures") || productionCompanies.Contains("Walt Disney Productions")) {

                        movieName = retrievedMovies.results[i].title;

                        if (!movies.Contains(movieName)) {
                            movieFound = true;
                            break;
                        }
                    }
                }

            } while (!movieFound);

            return new Movie(movieName);
        }
    }
}
