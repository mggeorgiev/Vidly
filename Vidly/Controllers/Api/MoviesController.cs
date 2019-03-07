using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        //Create DB context
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        [HttpPost]
        public Movie CreateMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return movie;
        }

        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            movieInDB.DateAdded = movie.DateAdded;
            movieInDB.GenreTypeId = movie.GenreTypeId;
            movieInDB.Name = movie.Name;
            movieInDB.NumberInStock = movie.NumberInStock;
            movieInDB.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();

        }


        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();
        }
    }
}
