using DataAccess.Contract;
using DataAccess.Models;
using DataAccess.Models.Tables;
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
    public class ActorsController : ControllerBase
    {
        private readonly IActorsDataAccess _actorsDataAccess;

        public ActorsController(IActorsDataAccess actorsDataAccess)
        {
            _actorsDataAccess = actorsDataAccess;
        }

        [HttpGet("GetActors")]
        public List<Actors> GetActors()
        {
            return _actorsDataAccess.GetActors();
        }

        [HttpGet("GetActor")]
        public Actors GetActor(int id)
        {
            return _actorsDataAccess.GetActor(id);
        }

        [HttpPost("InsertActor")]
        public bool InsertActor(Actors actor)
        {
            return _actorsDataAccess.InsertActor(actor);
        }

        [HttpPut("UpdateActor")]
        public bool UpdateActor(Actors actor)
        {
            return _actorsDataAccess.UpdateActor(actor);
        }

        [HttpDelete("DeleteActor")]
        public bool DeleteActor(int id)
        {
            return _actorsDataAccess.DeleteActor(id);
        }
    }
}
