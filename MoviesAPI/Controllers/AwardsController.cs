using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO.Awards;
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
    public class AwardsController : ControllerBase
    {
        private readonly IAwardsInfrastructure _infrastructure;

        public AwardsController(IAwardsInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        /// <summary>
        /// Get list a award
        /// </summary>
        /// <response code="200">Success opration and return Lists object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object</returns>
        [HttpGet("GetAwards")]
        public List<AwardsDTO> GetAwards()
        {
            return _infrastructure.GetAwards();
        }
        /// <summary>
        /// Get a award by id
        /// </summary>
        /// <response code="200">Success opration and return object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>DTO from object</returns>
        [HttpGet("GetAward")]
        public AwardsDTO GetAward(int id)
        {
            return _infrastructure.GetAward(id);
        }
        /// <summary>
        /// Insert award with DTO
        /// </summary>
        /// <response code="200">Success opration and return true.</response>
        /// <response code="400">An error ocurred on the server and return false.</response>
        /// <returns>True or false</returns>
        [HttpPost("InsertAward")]
        public bool InsertAward(AwardsInsertDTO award)
        {
            return _infrastructure.InsertAward(award);
        }
        /// <summary>
        /// Update award by id with DTO
        /// </summary>
        /// <response code="200">Success opration and return true if update.</response>
        /// <response code="400">An error ocurred on the server false if not insert.</response>
        /// <returns>True or false</returns>
        [HttpPut("UpdateAward")]
        public bool UpdateAward(AwardsUpdateDTO award)
        {
            return _infrastructure.UpdateAward(award);
        }
        /// <summary>
        /// Delete a  award by id
        /// </summary>
        /// <response code="200">Success opration and return true if delete..</response>
        /// <response code="400">An error ocurred on the server return false.</response>
        /// <returns>True or false</returns>
        [HttpDelete("DeleteAward")]
        public bool DeleteAward(int id)
        {
            return _infrastructure.DeleteAward(id);
        }
    }
}
