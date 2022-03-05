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
        /// <summary>
        /// Get a movie for method by id
        /// </summary>
        /// <response code="200">Success opration and return movie object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>return object Movies</returns>
        [HttpGet("GetMovieByMethod")]
        public Movies GetMovieByMethod(int id)
        {
            return _moviesInfrastructure.GetMovieByMethod(id);
        }
        /// <summary>
        /// Get list cinemasDTO from the database
        /// </summary>
        /// <response code="200">Success opration and return cinemaDTO.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List objects DTO cinemas</returns>
        [HttpGet("GetCinemas")]
        public List<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> movies = _moviesInfrastructure.GetCinemas().ToList();
            return movies;
        }
        /// <summary>
        /// Get a cinemaDTO by id
        /// </summary>
        /// <response code="200">Success opration and return cinemaDTO object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>object cinemaDTO</returns>
        [HttpGet("GetCinema")]
        public CinemaDTO GetCinema(int movieId)
        {
            return _moviesInfrastructure.GetCinema(movieId);
        }
        /// <summary>
        /// Get example extension to get a string
        /// </summary>
        /// <response code="200">Success opration and return string.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>string type</returns>
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
        /// <summary>
        /// Get a list from MoviesDTO
        /// </summary>
        /// <response code="200">Success opration and return List MoviesDTO object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object Movies</returns>
        [HttpGet("GetMoviesDetails")]
        public List<MoviesDTO> GetMoviesDetails()
        {
            return _moviesInfrastructure.GetMoviesDetails();
        }
        /// <summary>
        /// Valid the string title is valite in the database
        /// </summary>
        /// <response code="200">Success opration and return validate string.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>string with valide text</returns>
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
        public IActionResult InsertMovie(MoviesInsertDTO movieDTO)
        {
            try
            {
                if (_moviesInfrastructure.InsertMovie(movieDTO))
                {
                    return Ok();
                }
                return BadRequest("Error to insert movie in database");
            }
            catch (Exception e)
            {
                return BadRequest($"Server internal error {e.Message}");
            }
        }
        #endregion
        #region PUT
        /// <summary>
        /// Update movie by id with DTO
        /// </summary>
        /// <response code="200">Success opration and return true if update.</response>
        /// <response code="400">An error ocurred on the server false if not insert.</response>
        /// <returns>True or false</returns>
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(MoviesUpdateDTO movieDTO)
        {
            try
            {
                if (_moviesInfrastructure.UpdateMovie(movieDTO))
                {
                    return Ok();
                }
                return BadRequest("Error to update movie in database");
            }
            catch (Exception e)
            {
                return BadRequest($"Server internal error {e.Message}");
            }
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
        public ActionResult DeleteMovie(int id)
        {
            try
            {
                if (_moviesInfrastructure.DeleteMovie(id))
                {
                    return Ok();
                }
                return BadRequest("Error to delete the movie in database");
            }
            catch (Exception e)
            {
                return BadRequest($"Server internal error {e.Message}");
            }
        }
        #endregion
    }
}
