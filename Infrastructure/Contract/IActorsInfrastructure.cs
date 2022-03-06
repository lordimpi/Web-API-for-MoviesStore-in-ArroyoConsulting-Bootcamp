using Infrastructure.DTO.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public interface IActorsInfrastructure
    {
        bool DeleteActor(int id);
        ActorsDTO GetActor(int id);
        List<ActorsDTO> GetActors();
        bool InsertActor(ActorsInsertDTO moviesActorDTO);
        bool UpdateActor(ActorsUpdateDTO moviesActorDTO);
    }
}
