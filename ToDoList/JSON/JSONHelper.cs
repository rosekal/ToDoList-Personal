using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.JSON {
    class JSONHelper {
        public static string GetTopRatedMovies() {
            Random r = new Random();

            using (WebClient wc = new WebClient()) {
                return wc.DownloadString("http://api.themoviedb.org/3/movie/top_rated?api_key=82c4633a67bf083157ad5991c2196d94&language=en-US&page=" + r.Next(1, 10));
            }
        }

        public static string GetDisneyMovies() {
            Random r = new Random();

            using (WebClient wc = new WebClient()) {
                return wc.DownloadString("https://api.themoviedb.org/3/movie/11224/similar?api_key=82c4633a67bf083157ad5991c2196d94&language=en-US&page=1");
            }
        }

        public static string GetMovieDetails(int id) {
            using (WebClient wc = new WebClient()) {
                return wc.DownloadString("https://api.themoviedb.org/3/movie/"+id+"?api_key=82c4633a67bf083157ad5991c2196d94&language=en-US");
            }
        }
    }
}
