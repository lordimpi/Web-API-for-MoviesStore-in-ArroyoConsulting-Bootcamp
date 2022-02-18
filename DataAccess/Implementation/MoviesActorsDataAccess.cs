using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class MoviesActorsDataAccess : IMoviesActorsDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesActorsDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteMovieActor(int id)
        {
            var movieActor = _dbContext.MoviesActors.Find(id);
            _dbContext.Remove(movieActor);
            return _dbContext.SaveChanges() > 0;
        }

        public MoviesActors GetMoviesActor(int id)
        {
            var movieActor = (
                from mva in _dbContext.MoviesActors
                where mva.MovieActorId == id
                select mva).FirstOrDefault();
            return movieActor;
        }

        public List<MoviesActors> GetMoviesActors()
        {
            List<MoviesActors> moviesActors = (
                from mva in _dbContext.MoviesActors
                select mva).ToList();
            return moviesActors;
        }

        public bool InsertMovieActor(MoviesActors moviesActor)
        {
            _dbContext.Add(moviesActor);
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateMovieActor(MoviesActors moviesActor)
        {
            _dbContext.Entry(moviesActor).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
