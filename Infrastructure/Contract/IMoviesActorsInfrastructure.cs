using Infrastructure.DTO.MoviesActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public interface IMoviesActorsInfrastructure
    {
        bool DeleteMoviesActor(int id);
        MoviesActorsDTO GetMoviesActor(int id);
        List<MoviesActorsDTO> GetMoviesActors();
        bool InsertMoviesActor(MoviesActorsInsertDTO moviesActorDTO);
        bool UpdateMoviesActor(MoviesActorsUpdateDTO moviesActorDTO);
    }
}
