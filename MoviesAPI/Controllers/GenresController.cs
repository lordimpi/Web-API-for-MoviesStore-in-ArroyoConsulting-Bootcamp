using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO.Genres;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresInfrastructure _infrastructure;

        public GenresController(IGenresInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        /// <summary>
        /// Get list a genres
        /// </summary>
        /// <response code="200">Success opration and return Lists object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>List DTO from object</returns>
        [HttpGet("GetGenres")]
        public List<GenresDTO> GetGenres()
        {
            return _infrastructure.GetGenres();
        }
        /// <summary>
        /// Get a genre by id
        /// </summary>
        /// <response code="200">Success opration and return object.</response>
        /// <response code="400">An error ocurred on the server.</response>
        /// <returns>DTO from object</returns>
        [HttpGet("GetGenre")]
        public GenresDTO GetGenre(int id)
        {
            return _infrastructure.GetGenre(id);
        }
        /// <summary>
        /// Insert genre with DTO
        /// </summary>
        /// <response code="200">Success opration and return true.</response>
        /// <response code="400">An error ocurred on the server and return false.</response>
        /// <returns>True or false</returns>
        [HttpPost("InsertGenre")]
        public bool InsertGenre(GenresInsertDTO genre)
        {
            return _infrastructure.InsertGenre(genre);
        }
        /// <summary>
        /// Update genre by id with DTO
        /// </summary>
        /// <response code="200">Success opration and return true if update.</response>
        /// <response code="400">An error ocurred on the server false if not insert.</response>
        /// <returns>True or false</returns>
        [HttpPut("UpdateGenre")]
        public bool UpdateGenre(GenresUpdateDTO genre)
        {
            return _infrastructure.UpdateGenre(genre);
        }
        /// <summary>
        /// Delete a  genre by id
        /// </summary>
        /// <response code="200">Success opration and return true if delete..</response>
        /// <response code="400">An error ocurred on the server return false.</response>
        /// <returns>True or false</returns>
        [HttpDelete("DeleteGenre")]
        public bool DeleteGenre(int id)
        {
            return _infrastructure.DeleteGenre(id);
        }
    }
}
