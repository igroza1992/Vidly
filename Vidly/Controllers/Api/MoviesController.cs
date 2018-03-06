using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController:ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movie
        public IEnumerable<MovieDto> GetMovieDtos()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }


        //GET /api/movie/id
        public IHttpActionResult GetMovie(int id)
        {
            var getMovie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (getMovie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(getMovie));

        }

        //POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movieInDb);
            _context.SaveChanges();

            movieDto.Id = movieInDb.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieInDb.Id), movieDto);
        }
        //PUT /api/movie
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            
        }

        //DELETE /api/movie
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}