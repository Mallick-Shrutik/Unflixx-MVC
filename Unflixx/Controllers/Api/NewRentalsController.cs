using System;
using System.Linq;
using System.Web.Http;
using Unflixx.Dtos;
using Unflixx.Models;

namespace Unflixx.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //the following if statement is Edge Case 1(Defensive Approach)
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given");
            }

            //SingleOrDefault is a defensive approach while Single is an optimistic approach
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId); //_context.Customers.Single(c => c.Id == newRental.CustomerId); This is an optimistic way

            //the following if statement is Edge Case 2(Defensive approach)
            if (customer == null)
            {
                return BadRequest("CustomerId is Invalid");
            }
            
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //the following if statement is Edge Case 3(Defensive approach)
            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more MovieIds is Invalid");
            }

            foreach(var movie in movies)
            {
                if(movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
                
            };

            _context.SaveChanges();

            return Ok();
        }
    }
}
