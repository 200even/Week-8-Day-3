using Media_Manager.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Media_Manager.Controllers
{
    public class HomeController : Controller
    {
        private MovieModel db = new MovieModel();

        public ActionResult Index()
        {
            WebClient wc = new WebClient();
            var json = wc.DownloadString("C:/Users/Scott/Documents/Sublime/movies");
            var myMovies = JsonConvert.DeserializeObject<List<SimpleMovie>>(json);

            List<Movie> movies = new List<Movie>();
            var client = new RestClient();
            client.BaseUrl = new Uri("http://www.omdbapi.com/?");
            List<SimpleMovie> notFound = new List<SimpleMovie>();
            foreach (SimpleMovie m in myMovies)
            {
                var request = new RestRequest();
                request.Method = Method.GET;
                request.AddParameter("t", m.Movie);
                request.AddParameter("y", m.Year);

                var response = client.Execute<Movie>(request);
                if (response.Data.imdbID == null)
                {
                    notFound.Add(m);
                }
                else
                {
                    movies.Add(response.Data);
                }
            }
            List<Movie> newMovies = new List<Movie>();
            foreach (Movie m in movies)
            {
                if (!db.Movies.Any(x => x.imdbID == m.imdbID))
                {
                    db.Movies.Add(m);
                    newMovies.Add(m);
                }
            }
            db.SaveChanges();
            return View(newMovies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}