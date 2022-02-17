using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    public interface IMoviesDataAccess
    {
        List<Movies> GetMovies();
        Movies GetMovie(int id);
        bool InsertMovie(Movies movie);
        bool UpdateMovie(Movies movie);
        bool DeleteMovie(int id);
    }
}
