using DataAccess.Models;
using DataAccess.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    public interface IMoviesActorsDataAccess
    {
        List<MoviesActors> GetMoviesActors();
        MoviesActors GetMoviesActor(int id);
        bool InsertMovieActor(MoviesActors moviesActor);
        bool UpdateMovieActor(MoviesActors moviesActor);
        bool DeleteMovieActor(int id);
    }
}
