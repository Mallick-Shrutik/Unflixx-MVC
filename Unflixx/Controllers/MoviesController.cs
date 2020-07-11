using System;
using System.Data.Entity; //added to remove the error from m.Genre
using System.Linq;
using System.Web.Mvc;
using Unflixx.Models;
using Unflixx.ViewModels;
using System.Collections.Generic;

namespace Unflixx.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: Movies
        public ViewResult Index()
        {
            // var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List"); //return View(movies);
            }

            return View("ReadOnlyList");
            
        }

        [Authorize(Roles = RoleName.CanManageMovies)] //will not allow modification of movie from api calls or url
        public ViewResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new GenresViewModel
            {
                
                Genres = genre
            };
            return View("Edit",viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new GenresViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };
            return View("Edit",viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new GenresViewModel(movie)
                {
                    
                    Genres = _context.Genres.ToList()
                };
                return View("Edit", viewModel);
            }


            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStocks = movie.NumberInStocks;
                movieInDb.GenreId = movie.GenreId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        
       

       
       


        // GET: Movies Random
        /*public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Avengers : Endgame"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Zack"},
                new Customer {Name = "Tony"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);


            //we can also return view using ViewData and ViewBag but it is not recommended
            //return new ViewResult(); Can also be written like these which is common among developers
        }

        /*public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex = {0} and sortBy = {1}", pageIndex, sortBy));
        }

        //below is the actual use of attribute routing after enabling it in RoutesConfig
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
            //return View();
        }
        */
    }
}