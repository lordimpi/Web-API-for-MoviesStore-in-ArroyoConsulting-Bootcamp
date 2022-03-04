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
        /// <summary>
        /// Get list a movies with details
        /// </summary>
        /// <response code="200">Success opration and return Lists of movies object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object Movies</returns>
        [HttpGet("GetMovies")]
        public List<MoviesDTO> GetMovies()
        {
            return _moviesInfrastructure.GetMovies();
        }
        /// <summary>
        /// Get list a movies with details
        /// </summary>
        /// <response code="200">Success opration and return Lists of movies object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object Movies</returns>
        [HttpGet("GetMoviesByMethod")]
        public List<Movies> GetMoviesByMethod()
        {
            return _moviesInfrastructure.GetMoviesByMethod();
        }
        /// <summary>
        /// Get list of movie by title
        /// </summary>
        /// <response code="200">Success opration and return Lists of movies object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List from object Movies</returns>
        [HttpGet("GetMovieByTitle")]
        public List<Movies> GetMovieByTitle(string title)
        {
            return _moviesInfrastructure.GetMoviesByTitle(title);
        }
        /// <summary>
        /// Get a movie by id
        /// </summary>
        /// <response code="200">Success opration and return movie object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object Movies</returns>
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
        /// <returns>DTO from object Movie</returns>
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
        /// <summary>
        /// Insert movie with DTO
        /// </summary>
        /// <response code="200">Success opration and return true.</response>
        /// <response code="400">An error ocurred on the server and return false.</response>
        /// <returns>True or false</returns>
        [HttpPost("InsertMovie")]
        public bool InsertMovie(Movies movie)
        {
            return _moviesInfrastructure.InsertMovie(movie);
        }
        #endregion
        #region PUT
        /// <summary>
        /// Update movie by id
        /// </summary>
        /// <response code="200">Success opration and return true if update.</response>
        /// <response code="400">An error ocurred on the server false if not insert.</response>
        /// <returns>True or false</returns>
        [HttpPut("UpdateMovie")]
        public bool UpdateMovie(Movies movie)
        {
            return _moviesInfrastructure.UpdateMovie(movie);
        }
        #endregion
        #region DELETE
        /// <summary>
        /// Delete a movie by id
        /// </summary>
        /// <response code="200">Success opration and return true if delete..</response>
        /// <response code="400">An error ocurred on the server return false.</response>
        /// <returns>True if insert. False if not insert</returns>
        [HttpDelete("DeleteMovie")]
        public bool DeleteMovie(int id)
        {
            return _moviesInfrastructure.DeleteMovie(id);
        }
        #endregion
    }
}
