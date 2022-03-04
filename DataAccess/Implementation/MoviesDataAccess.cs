using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.DTO;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementation
{
    public class MoviesDataAccess : IMoviesDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region GET
        public List<Movies> GetMovies()
        {
            List<Movies> movies = _dbContext.Movies
                .Include(gn => gn.Genre)
                .Include(aw => aw.Award)
                .ToList();

            //List<Movies> movies = (
            //    from mv in _dbContext.Movies
            //    join gn in _dbContext.Genres
            //    on mv.GenreId equals gn.GenreId
            //    join aw in _dbContext.Awards
            //    on mv.AwardId equals aw.AwardId
            //    select mv).ToList();

            return movies;
        }
        public List<Movies> GetMoviesByMethod()
        {
            return _dbContext.Movies.ToList();
        }
        public Movies GetMovieByMethod(int id)
        {
            return _dbContext.Movies.Where(mv => mv.MovieId == id).FirstOrDefault();
        }
        public List<Movies> GetMoviesByTitle(string title)
        {
            //Syntax linq
            List<Movies> movies1 = (
                from mv in _dbContext.Movies
                    //where mv.Title.Contains(title)
                    //where mv.Title.StartWith(title) //'Text%'
                    //where mv.Title.EndsWith(title) //'%Text'
                where mv.Title == title
                orderby mv.Title ascending
                select mv
                ).ToList();

            //Method ling
            List<Movies> movies2 = _dbContext.Movies
                .Where(mv => mv.Title == title)
                .OrderBy(mv => mv.Title)
                .ToList();

            //Method and Syntax
            List<Movies> movies3 = (
                from mv in _dbContext.Movies
                where mv.Title.StartsWith(title)
                select mv).OrderBy(x => x.Title).ToList();

            return movies2;
        }
        public List<CinemaDTO> GetCinemas()
        {
            List<CinemaDTO> cinemas = (
                from mv in _dbContext.Movies
                join g in _dbContext.Genres
                on mv.GenreId equals g.GenreId
                select new CinemaDTO
                {
                    Title = mv.Title,
                    Description = mv.Description,
                    Release = mv.Release,
                    Time = $"{mv.RunningTime} minutes",
                    Genre = g.Genre
                }).ToList();
            return cinemas;
        }
        public Movies GetCinema(int movieId)
        {
            //mv.Genre obj con datos
            //Movies movie1 = (
            //                from mv in _dbContext.Movies
            //                where mv.MovieId == movieId
            //                select new Movies
            //                {
            //                    MovieId = mv.MovieId,
            //                    Title = mv.Title,
            //                    Description = mv.Description,
            //                    Release = mv.Release,
            //                    RunningTime = mv.RunningTime,
            //                    GenreId = mv.GenreId,
            //                    Genre = mv.Genre
            //                }).FirstOrDefault();

            //mv.Genre obj genero en null
            //Movies movie2 = (
            //    from mv in _dbContext.Movies
            //    where mv.MovieId == movieId
            //    select mv).FirstOrDefault();

            Movies movie = (
                from mv in _dbContext.Movies
                where mv.MovieId == movieId
                select mv)
                .Include(x => x.Genre)
                .FirstOrDefault();

            return movie;
        }
        public Movies GetMovie(int id)
        {
            Movies movie = (
                from mv in _dbContext.Movies
                where mv.MovieId == id
                select mv).FirstOrDefault();

            return movie;
            //return _dbContext.Movies.Find(id);
        }
        public Movies GetMovieDetails(int id)
        {
            Movies movie = (
                from mv in _dbContext.Movies
                where mv.MovieId == id
                select mv)
                .Include(gn => gn.Genre)
                .Include(aw => aw.Award)
                .FirstOrDefault();

            return movie;
        }
        public List<Movies> GetMoviesDetails()
        {
            List<Movies> movies = _dbContext.Movies
                .Include(gn => gn.Genre)
                .Include(aw => aw.Award).ToList();

            return movies;
        }
        #endregion

        public bool InsertMovie(Movies movie)
        {
            _dbContext.Add(movie);
            return _dbContext.SaveChanges() > 0;
        }
        public bool UpdateMovie(Movies movie)
        {
            _dbContext.Entry(movie).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
        public bool DeleteMovie(int id)
        {
            Movies movie = _dbContext.Movies.Find(id);
            _dbContext.Remove(movie);
            return _dbContext.SaveChanges() > 0;
        }


    }
}
