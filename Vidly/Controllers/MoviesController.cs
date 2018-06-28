using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        // ctor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        [Route("movies")]
        public ActionResult Index()
        {
            //var movies = new List<Movie>
            //{
            //    new Movie { Name = "Game of Thrones" },
            //    new Movie { Name = "Breaking bad" }
            //};

            //var movieViewModel = new MovieViewModel
            //{
            //    Movies = movies
            //};
            //return View(movieViewModel);
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Game of Thrones" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };


        //    return View(viewModel);

        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        //public ActionResult Edit(int id)
        //{
        //    return Content("Id: " + id);
        //}
    }
}