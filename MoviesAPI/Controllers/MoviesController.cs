using DataAccess.Contract;
using DataAccess.Models.DTO;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
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
        private readonly IMoviesInfrastructure _moviesInfrastructure;

        public MoviesController(IMoviesInfrastructure moviesInfrastructure)
        {
            _moviesInfrastructure = moviesInfrastructure;
        }

        #region GET
        [HttpGet("GetMovies")]
        public List<MoviesDTO> GetMovies()
        {
            return _moviesInfrastructure.GetMovies();
        }
        [HttpGet("GetMoviesByMethod")]
        public List<Movies> GetMoviesByMethod()
        {
            return _moviesInfrastructure.GetMoviesByMethod();
        }
        [HttpGet("GetMovieByTitle")]
        public List<Movies> GetMovieByTitle(string title)
        {
            return _moviesInfrastructure.GetMoviesByTitle(title);
        }
        [HttpGet("GetMovie")]
        public MoviesDTO GetMovie(int id)
        {
            return _moviesInfrastructure.GetMovie(id);
        }
        [HttpGet("GetMovieByMethod")]
        public Movies GetMovieByMethod(int id)
        {
            return _moviesInfrastructure.GetMovieByMethod(id);
        }
        [HttpGet("GetCinemas")]
        public List<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> movies = _moviesInfrastructure.GetCinemas().ToList();
            return movies;
        }
        [HttpGet("GetCinema")]
        public CinemaDTO GetCinema(int movieId)
        {
            return _moviesInfrastructure.GetCinema(movieId);
        }
        [HttpGet("ExampleExtensionsMethod")]
        public string ExampleExtensionsMethod(string name)
        {
            return _moviesInfrastructure.ExampleExtensionsMethod(name);
        }
        /// <summary>
        /// Get movie details by id
        /// </summary>
        /// <param name="movieId">id for search</param>
        /// <response code="200">Success opration and return movie object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns></returns>
        [HttpGet("GetMovieDetails")]
        public MoviesDTO GetMovieDetails(int movieId)
        {
            return _moviesInfrastructure.GetMovieDetails(movieId);
        }

        [HttpGet("GetMoviesDetails")]
        public List<MoviesDTO> GetMoviesDetails()
        {
            return _moviesInfrastructure.GetMoviesDetails();
        }

        [HttpGet("ValidateTitleMovie")]
        public string ValidateTitleMovie(string title)
        {
            return _moviesInfrastructure.ValidateTitleMovie(title);
        }

        #endregion
        #region POST

        [HttpPost("InsertMovie")]
        public bool InsertMovie(Movies movie)
        {
            return _moviesInfrastructure.InsertMovie(movie);
        }
        #endregion
        #region PUT

        [HttpPut("UpdateMovie")]
        public bool UpdateMovie(Movies movie)
        {
            return _moviesInfrastructure.UpdateMovie(movie);
        }
        #endregion
        #region DELETE

        [HttpDelete("DeleteMovie")]
        public bool DeleteMovie(int id)
        {
            return _moviesInfrastructure.DeleteMovie(id);
        }
        #endregion
    }
}
