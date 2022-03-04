using DataAccess.Models.DTO;
using DataAccess.Models.Tables;
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
        List<Movies> GetMoviesByMethod();
        List<Movies> GetMoviesByTitle(string title);
        Movies GetMovie(int id);
        Movies GetMovieByMethod(int id);
        List<CinemaDTO> GetCinemas();
        bool InsertMovie(Movies movie);
        bool UpdateMovie(Movies movie);
        bool DeleteMovie(int id);
        Movies GetCinema(int movieId);
        Movies GetMovieDetails(int id);
        List<Movies> GetMoviesDetails();
    }
}
