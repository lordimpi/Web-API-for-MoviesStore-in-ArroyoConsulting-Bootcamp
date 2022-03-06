using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO.Actors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsInfrastructure _infrastructure;

        public ActorsController(IActorsInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        /// <summary>
        /// Get list a actors
        /// </summary>
        /// <response code="200">Success opration and return Lists object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object</returns>
        [HttpGet("GetActors")]
        public List<ActorsDTO> GetActors()
        {
            return _infrastructure.GetActors();
        }
        /// <summary>
        /// Get a actor by id
        /// </summary>
        /// <response code="200">Success opration and return object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>DTO from object</returns>
        [HttpGet("GetActor")]
        public ActorsDTO GetActor(int id)
        {
            return _infrastructure.GetActor(id);
        }
        /// <summary>
        /// Insert actor with DTO
        /// </summary>
        /// <response code="200">Success opration and return true.</response>
        /// <response code="400">An error ocurred on the server and return false.</response>
        /// <returns>True or false</returns>
        [HttpPost("InsertActor")]
        public bool InsertActor(ActorsInsertDTO actor)
        {
            return _infrastructure.InsertActor(actor);
        }
        /// <summary>
        /// Update actor by id with DTO
        /// </summary>
        /// <response code="200">Success opration and return true if update.</response>
        /// <response code="400">An error ocurred on the server false if not insert.</response>
        /// <returns>True or false</returns>
        [HttpPut("UpdateActor")]
        public bool UpdateActor(ActorsUpdateDTO actor)
        {
            return _infrastructure.UpdateActor(actor);
        }
        /// <summary>
        /// Delete a  actor by id
        /// </summary>
        /// <response code="200">Success opration and return true if delete..</response>
        /// <response code="400">An error ocurred on the server return false.</response>
        /// <returns>True or false</returns>
        [HttpDelete("DeleteActor")]
        public bool DeleteActor(int id)
        {
            return _infrastructure.DeleteActor(id);
        }
    }
}
