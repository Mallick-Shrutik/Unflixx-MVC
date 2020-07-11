using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Unflixx.Dtos;
using Unflixx.Models;

namespace Unflixx.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies.Include(c => c.Genre).Where(c => c.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));
            }
            
            var movieDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if(movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie , MovieDto>(movie));
        }

        //POST /api/movieDto
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto );
        }

        //PUT /api/movieDto/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var moviesInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(movieDto, moviesInDb);
                        
            _context.SaveChanges();
        }

        //DELETE /api/movieDto/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var moviesInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (moviesInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(moviesInDb);
            _context.SaveChanges();
        }
    }
}
