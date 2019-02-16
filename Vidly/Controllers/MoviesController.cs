using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using PagedList;

namespace Vidly.Controllers
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

        // GET: Movies
        public ActionResult Index(string movieGenre, string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.GenreSortParam = sortOrder == "Genre" ? "genre_desc" : "Genre" ;
            ViewBag.ItemsSortParam = sortOrder == "Items" ? "items_desc" : "Items";
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentGenre = movieGenre;
            ViewBag.CurrentSearch = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var GenreLst = new List<string>();

            var GenreQry = from g in _context.GenreTypes
                           orderby g.Name
                           select g.Name;

            GenreLst.AddRange(GenreQry.Distinct());


            ViewBag.movieGenre = new SelectList(GenreLst);

            //var movies = _context.Movies.Include("GenreType").ToList();
            var movies = (from m in _context.Movies
                             join g in _context.GenreTypes on m.GenreTypeId equals g.Id
                             select m).Include("GenreType");



            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                movies = movies.Where(m => m.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(m => m.GenreType.Name.Contains(movieGenre));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Name);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.ReleaseDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseDate);
                    break;
                case "Genre":
                    movies = movies.OrderBy(m => m.GenreType.Name);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(m => m.GenreType.Name);
                    break;
                case "Items":
                    movies = movies.OrderBy(m => m.NumberInStock);
                    break;
                case "items_desc":
                    movies = movies.OrderByDescending(m => m.NumberInStock);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Name);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);


            return View(movies.ToPagedList(pageNumber, pageSize));
            }

        // GET: Details
        public ActionResult Details(int Id)
        {

            var movies = _context.Movies.Include("GenreType").SingleOrDefault(m => m.Id == Id);


            return View(movies);
        }

        public ActionResult Random(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex ={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    GenreTypes = _context.GenreTypes.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Id = movie.Id;
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New ()
        {
            var genreTypes = _context.GenreTypes.ToList();

            var viewModel = new MovieFormViewModel
            {
                GenreTypes = genreTypes,
                Movie = new Movie
                {
                    DateAdded = DateTime.Now
                } 
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                GenreTypes= _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}