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
    public class GenresController : ControllerBase
    {
        private readonly IGenresDataAccess _genresDataAccess;

        public GenresController(IGenresDataAccess genresDataAccess)
        {
            _genresDataAccess = genresDataAccess;
        }

        [HttpGet("GetGenres")]
        public List<Genres> GetGenres()
        {
            return _genresDataAccess.GetGenres();
        }

        [HttpGet("GetGenre")]
        public Genres GetGenre(int id)
        {
            return _genresDataAccess.GetGenre(id);
        }

        [HttpPost("InsertGenre")]
        public bool InsertGenre(Genres genre)
        {
            return _genresDataAccess.InsertGenre(genre);
        }

        [HttpPut("UpdateGenre")]
        public bool UpdateGenre(Genres genre)
        {
            return _genresDataAccess.UpdateGenre(genre);
        }

        [HttpDelete("DeleteGenre")]
        public bool DeleteGenre(int id)
        {
            return _genresDataAccess.DeleteGenre(id);
        }
    }
}
