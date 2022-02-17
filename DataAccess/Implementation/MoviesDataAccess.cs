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
    public class MoviesDataAccess : IMoviesDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public MoviesDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movies> GetMovies()
        {
            List<Movies> movies = (
                from mv in _dbContext.Movies
                select mv).ToList();
            return movies;
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
            var movie = _dbContext.Movies.Find(id);
            _dbContext.Remove(movie);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
