using DataAccess.Models.DTO;
using DataAccess.Models.Tables;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public interface IMoviesInfrastructure
    {
        public List<MoviesDTO> GetMovies();
        public MoviesDTO GetMovie(int id);
        public bool InsertMovie(Movies movie);
        public bool UpdateMovie(Movies movie);
        public bool DeleteMovie(int id);
        List<Movies> GetMoviesByMethod();
        List<Movies> GetMoviesByTitle(string title);
        public List<CinemaDTO> GetCinemas();
        Movies GetMovieByMethod(int id);
        CinemaDTO GetCinema(int movieId);
        string ExampleExtensionsMethod(string name);
        string ValidateTitleMovie(string title);
        MoviesDTO GetMovieDetails(int movieId);
        List<MoviesDTO> GetMoviesDetails();
    }
}
