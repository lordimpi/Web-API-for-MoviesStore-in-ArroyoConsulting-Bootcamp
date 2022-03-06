using Infrastructure.Contract;
using Infrastructure.DTO.MoviesActors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesActorsController : ControllerBase
    {
        private readonly IMoviesActorsInfrastructure _infrastructure;

        public MoviesActorsController(IMoviesActorsInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        /// <summary>
        /// Get list a movies actors
        /// </summary>
        /// <response code="200">Success opration and return Lists object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object</returns>
        [HttpGet("GetMoviesActors")]
        public List<MoviesActorsDTO> GetMoviesActors()
        {
            return _infrastructure.GetMoviesActors();
        }
        /// <summary>
        /// Get a movies actor by id
        /// </summary>
        /// <response code="200">Success opration and return object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>DTO from object</returns>
        [HttpGet("GetMoviesActor")]
        public MoviesActorsDTO GetMoviesActor(int id)
        {
            return _infrastructure.GetMoviesActor(id);
        }
        /// <summary>
        /// Insert movies actor with DTO
        /// </summary>
        /// <response code="200">Success opration and return true.</response>
        /// <response code="400">An error ocurred on the server and return false.</response>
        /// <returns>True or false</returns>
        [HttpPost("InsertMoviesActor")]
        public bool InsertMoviesActor(MoviesActorsInsertDTO moviesActorDTO)
        {
            return _infrastructure.InsertMoviesActor(moviesActorDTO);
        }
        /// <summary>
        /// Update movies actors by id with DTO
        /// </summary>
        /// <response code="200">Success opration and return true if update.</response>
        /// <response code="400">An error ocurred on the server false if not insert.</response>
        /// <returns>True or false</returns>
        [HttpPut("UpdateMoviesActor")]
        public bool UpdateMoviesActor(MoviesActorsUpdateDTO moviesActorDTO)
        {
            return _infrastructure.UpdateMoviesActor(moviesActorDTO);
        }
        /// <summary>
        /// Delete a movies actor by id
        /// </summary>
        /// <response code="200">Success opration and return true if delete..</response>
        /// <response code="400">An error ocurred on the server return false.</response>
        /// <returns>True or false</returns>
        [HttpDelete("DeleteMoviesActor")]
        public bool DeleteMoviesActor(int id)
        {
            return _infrastructure.DeleteMoviesActor(id);
        }
    }
}
