using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class ActorsInfrastructure : IActorsInfrastructure
    {
        private readonly IActorsDataAccess _actorsDataAccess;

        public ActorsInfrastructure(IActorsDataAccess actorsDataAccess)
        {
            _actorsDataAccess = actorsDataAccess;
        }

        public List<ActorsDTO> GetActors()
        {
            List<Actors> actors = _actorsDataAccess.GetActors();
            List<ActorsDTO> actorsDTOs = actors.Select(act => new ActorsDTO
            {
                FullName = act.FullName
            }).ToList();
            return actorsDTOs;
        }

        public ActorsDTO GetActor(int id)
        {
            Actors actor = _actorsDataAccess.GetActor(id);
            ActorsDTO actorDTO = new()
            {
                FullName = actor.FullName
            };
            return actorDTO;
        }

        public bool InsertActor(ActorsInsertDTO actorDTO)
        {
            Actors actor = new()
            {
                FullName = actorDTO.FullName
            };
            return _actorsDataAccess.InsertActor(actor);
        }

        public bool UpdateActor(ActorsUpdateDTO actorDTO)
        {
            Actors actor = new()
            {
                FullName = actorDTO.FullName,
                ActorId = actorDTO.ActorId
            };
            return _actorsDataAccess.UpdateActor(actor);
        }

        public bool DeleteActor(int id)
        {
            return _actorsDataAccess.DeleteActor(id);
        }
    }
}
