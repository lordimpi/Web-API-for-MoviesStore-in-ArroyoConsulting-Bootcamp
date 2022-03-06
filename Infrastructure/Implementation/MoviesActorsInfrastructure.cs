using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO.MoviesActors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class MoviesActorsInfrastructure : IMoviesActorsInfrastructure
    {
        private readonly IMoviesActorsDataAccess _moviesActorsDataAccess;

        public MoviesActorsInfrastructure(IMoviesActorsDataAccess moviesActorsDataAccess)
        {
            _moviesActorsDataAccess = moviesActorsDataAccess;
        }

        public List<MoviesActorsDTO> GetMoviesActors()
        {
            List<MoviesActors> movies = _moviesActorsDataAccess.GetMoviesActors();
            List<MoviesActorsDTO> moviesActorsDTOs = movies.Select(mva => new MoviesActorsDTO
            {
                ActorId = mva.ActorId,
                MovieId = mva.MovieId
            }).ToList();
            return moviesActorsDTOs;
        }

        public MoviesActorsDTO GetMoviesActor(int id)
        {
            MoviesActors moviesActors = _moviesActorsDataAccess.GetMoviesActor(id);
            MoviesActorsDTO moviesActorsDTO = new()
            {
                ActorId = moviesActors.ActorId,
                MovieId = moviesActors.MovieId
            };
            return moviesActorsDTO;
        }

        public bool InsertMoviesActor(MoviesActorsInsertDTO moviesActorDTO)
        {
            MoviesActors moviesActors = new()
            {
                ActorId = moviesActorDTO.ActorId,
                MovieId = moviesActorDTO.MovieId
            };
            return _moviesActorsDataAccess.InsertMovieActor(moviesActors);
        }

        public bool UpdateMoviesActor(MoviesActorsUpdateDTO moviesActorDTO)
        {
            MoviesActors moviesActor = new()
            {
                MovieActorId = moviesActorDTO.MovieActorId,
                MovieId = moviesActorDTO.MovieId,
                ActorId = moviesActorDTO.ActorId
            };
            return _moviesActorsDataAccess.UpdateMovieActor(moviesActor);
        }

        public bool DeleteMoviesActor(int id)
        {
            return _moviesActorsDataAccess.DeleteMovieActor(id);
        }
    }
}
