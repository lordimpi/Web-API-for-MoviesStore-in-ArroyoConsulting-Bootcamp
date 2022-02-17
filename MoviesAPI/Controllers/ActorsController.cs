using DataAccess.Contract;
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
    }
}
