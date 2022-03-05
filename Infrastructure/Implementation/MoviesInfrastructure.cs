using AutoMapper;
using DataAccess.Contract;
using DataAccess.Models.DTO;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class MoviesInfrastructure : IMoviesInfrastructure
    {
        private readonly IMoviesDataAccess _moviesDataAccess;
        private readonly IMapper _mapper;

        public MoviesInfrastructure(IMoviesDataAccess moviesDataAccess, IMapper mapper)
        {
            _moviesDataAccess = moviesDataAccess;
            _mapper = mapper;
        }

        #region GET
        public MoviesDTO GetMovie(int id)
        {
            Movies movie = _moviesDataAccess.GetMovie(id);
            MoviesDTO moviesDTO = _mapper.Map<MoviesDTO>(movie);
            return moviesDTO;
        }
        public Movies GetMovieByMethod(int id)
        {
            return _moviesDataAccess.GetMovieByMethod(id);
        }
        public List<MoviesDTO> GetMovies()
        {
            List<Movies> movies = _moviesDataAccess.GetMovies();
            List<MoviesDTO> moviesDTO = (from m in movies
                                         select new MoviesDTO
                                         {
                                             DescriptionMovie = m.Description,
                                             TitleMovie = m.Title,
                                             Release = m.Release.ToShortDate(),
                                             RunningTime = $"#{m.RunningTime} minutes"
                                         }).ToList();

            //List<MoviesDTO> moviesDTO_Method = movies.Select(m => new MoviesDTO
            //{
            //    DescriptionMovie = m.Description,
            //    TitleMovie = m.Title,
            //    Release = m.Release.ToShortDate(),
            //    RunningTime = $"#{m.RunningTime} minutes"
            //}).ToList();

            return moviesDTO;
        }
        public List<Movies> GetMoviesByMethod()
        {
            return _moviesDataAccess.GetMoviesByMethod();
        }
        public List<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> movies = _moviesDataAccess.GetCinemas().ToList();
            return movies;
        }
        public CinemaDTO GetCinema(int movieId)
        {
            Movies movie = _moviesDataAccess.GetCinema(movieId);
            CinemaDTO cinemaDTO = new()
            {
                Title = movie.Title,
                Description = movie.Description,
                ReleaseShort = movie.Release.ToShortDate(),
                Time = $"{movie.RunningTime}(s) minutes",
                Genre = movie.Genre.Genre
            };
            return cinemaDTO;
        }
        public MoviesDTO GetMovieDetails(int movieId)
        {
            Movies movie = _moviesDataAccess.GetMovieDetails(movieId);
            MoviesDTO movieDTO = new()
            {
                TitleMovie = movie.Title.ToAddCharacter(),
                DescriptionMovie = movie.Description.ToUpper(),
                Release = movie.Release.ToShortDate(),
                RunningTime = $"#{movie.RunningTime} minutes",
                Genre = movie.Genre.Genre.ToLower(),
                Award = movie.Award.AwardTitle.ToUpper()
            };
            return movieDTO;
        }
        public List<MoviesDTO> GetMoviesDetails()
        {
            List<Movies> movies = _moviesDataAccess.GetMovies();

            List<MoviesDTO> moviesDTOs = movies.Select(mv => new MoviesDTO
            {
                TitleMovie = mv.Title,
                DescriptionMovie = mv.Description,
                Award = mv.Award.AwardTitle,
                Genre = mv.Genre.Genre,
                Release = mv.Release.ToShortDate(),
                RunningTime = $"#{mv.RunningTime} minutes"
            }).ToList();

            //List<MoviesDTO> moviesDTOs2 = (
            //    from mv in movies
            //    select new MoviesDTO
            //    {
            //        TitleMovie = mv.Title,
            //        DescriptionMovie = mv.Description,
            //        Award = mv.Award.AwardTitle,
            //        Genre = mv.Genre.Genre,
            //        Release = mv.Release.ToShortDate(),
            //        RunningTime = $"#{mv.RunningTime} minutes"
            //    }).ToList();

            return moviesDTOs;
        }
        public string ExampleExtensionsMethod(string name)
        {
            //string nameHello = Extensions.ToHello(name);
            return name.ToHello().ToUpper().Trim();
        }
        public string ValidateTitleMovie(string title)
        {
            if (title.IsTitle())
            {
                return title.FormatText();
            }
            return "Error";
        }
        #endregion
        public bool DeleteMovie(int id)
        {
            return _moviesDataAccess.DeleteMovie(id);
        }

        public List<Movies> GetMoviesByTitle(string title)
        {
            if (title == null)
            {
                title = "";
            }
            else
            {
                title = title.ToLower().TrimEnd();
            }
            return _moviesDataAccess.GetMoviesByTitle(title);
        }

        public bool InsertMovie(MoviesInsertDTO movieDTO)
        {
            Movies movie = new()
            {
                Title = movieDTO.Title,
                AwardId = movieDTO.AwardId,
                Description = movieDTO.Description,
                GenreId = movieDTO.GenreId,
                Release = movieDTO.Release,
                RunningTime = movieDTO.RunningTime
            };

            return _moviesDataAccess.InsertMovie(movie);
        }

        public bool UpdateMovie(MoviesUpdateDTO movieDTO)
        {
            Movies movie = new Movies()
            {
                MovieId = movieDTO.MovieId,
                Title = movieDTO.Title.FormatText(),
                Description = movieDTO.Description.FormatText(),
                AwardId = movieDTO.AwardId,
                GenreId = movieDTO.GenreId,
                Release = movieDTO.Release,
                RunningTime = movieDTO.RunningTime
            };

            return _moviesDataAccess.UpdateMovie(movie);
        }
    }
}
