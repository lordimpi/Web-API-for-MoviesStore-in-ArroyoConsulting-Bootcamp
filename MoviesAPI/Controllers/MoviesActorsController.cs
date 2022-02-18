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
    public class MoviesActorsController : ControllerBase
    {
        private readonly IMoviesActorsDataAccess _moviesActorsDataAccess;

        public MoviesActorsController(IMoviesActorsDataAccess moviesActorsDataAccess)
        {
            _moviesActorsDataAccess = moviesActorsDataAccess;
        }

        [HttpGet("GetMoviesActors")]
        public List<MoviesActors> GetMoviesActors()
        {
            return _moviesActorsDataAccess.GetMoviesActors();
        }

        [HttpGet("GetMoviesActor")]
        public MoviesActors GetMoviesActor(int id)
        {
            return _moviesActorsDataAccess.GetMoviesActor(id);
        }

        [HttpPost("InsertMoviesActor")]
        public bool InsertMoviesActor(MoviesActors moviesActor)
        {
            return _moviesActorsDataAccess.InsertMovieActor(moviesActor);
        }

        [HttpPut("UpdateMoviesActor")]
        public bool UpdateMoviesActor(MoviesActors moviesActor)
        {
            return _moviesActorsDataAccess.UpdateMovieActor(moviesActor);
        }

        [HttpDelete("DeleteMoviesActor")]
        public bool DeleteMoviesActor(int id)
        {
            return _moviesActorsDataAccess.DeleteMovieActor(id);
        }
    }
}
