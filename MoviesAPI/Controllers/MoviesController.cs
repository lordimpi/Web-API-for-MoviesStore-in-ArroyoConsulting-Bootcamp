using DataAccess.Contract;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesDataAccess _moviesDataAccess;

        public MoviesController(IMoviesDataAccess moviesDataAccess)
        {
            _moviesDataAccess = moviesDataAccess;
        }
        
        [HttpGet("GetMovies")]
        public List<Movies> GetMovies()
        {
            return _moviesDataAccess.GetMovies();
        }

        [HttpGet("GetMovie")]
        public Movies GetMovie(int id)
        {
            return _moviesDataAccess.GetMovie(id);
        }

        [HttpPost("InsertMovie")]
        public bool InsertMovie(Movies movie)
        {
            return _moviesDataAccess.InsertMovie(movie);
        }

        [HttpPut("UpdateMovie")]
        public bool UpdateMovie(Movies movie)
        {
            return _moviesDataAccess.UpdateMovie(movie);
        }

        [HttpDelete("DeleteMovie")]
        public bool DeleteMovie(int id)
        {
            return _moviesDataAccess.DeleteMovie(id);
        }
    }
}
