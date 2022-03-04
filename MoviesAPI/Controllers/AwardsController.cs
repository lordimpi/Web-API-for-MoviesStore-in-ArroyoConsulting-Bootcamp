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
    public class AwardsController : ControllerBase
    {
        private readonly IAwardsInfrastructure _infrastructure;

        public AwardsController(IAwardsInfrastructure infrastructure)
        {
            _infrastructure = infrastructure;
        }

        [HttpGet("GetAwards")]
        public List<AwardsDTO> GetAwards()
        {
            return _infrastructure.GetAwards();
        }

        [HttpGet("GetAward")]
        public AwardsDTO GetAward(int id)
        {
            return _infrastructure.GetAward(id);
        }

        [HttpPost("InsertAward")]
        public bool InsertAward(Awards award)
        {
            return _infrastructure.InsertAward(award);
        }

        [HttpPut("UpdateAward")]
        public bool UpdateAward(Awards award)
        {
            return _infrastructure.UpdateAward(award);
        }

        [HttpDelete("DeleteAward")]
        public bool DeleteAward(int id)
        {
            return _infrastructure.DeleteAward(id);
        }
    }
}
