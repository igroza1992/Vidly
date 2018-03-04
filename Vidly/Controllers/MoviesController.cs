using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _conntext;

        public MoviesController()
        {
            _conntext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _conntext.Dispose();
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = _conntext.Movies.Include(c => c.Genres).ToList();
            
            
            return View(movies);
        }

        public ActionResult Edit(int Id)
        {
            var movies = _conntext.Movies.SingleOrDefault(x => x.Id == Id);
            if (movies == null)
                return HttpNotFound();

            var viewModel = new NewMoviesViewModel
            {
                Movie = movies,
                Genres = _conntext.Genres.ToList()
            };
            return View("NewMovies",viewModel);
            
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _conntext.Movies.Add(movie);
            else
            {
                var movieInDb = _conntext.Movies.Single(x => x.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenresId = movie.GenresId;
                movieInDb.Cuntity = movie.Cuntity;
            }
            _conntext.SaveChanges();
            return RedirectToAction("Random", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movies = _conntext.Movies.Include(x => x.Genres).SingleOrDefault(x => x.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _conntext.Genres.ToList();
            var ViewModel = new NewMoviesViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("NewMovies", ViewModel);
        }

       


        [Route("movies/release/{index}")]
        public ActionResult Random(int index)
        {

            return View();
        }
    }
}