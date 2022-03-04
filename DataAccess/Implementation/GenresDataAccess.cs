using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class GenresDataAccess : IGenresDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public GenresDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteGenre(int id)
        {
            var genre = _dbContext.Genres.Find(id);
            _dbContext.Remove(genre);
            return _dbContext.SaveChanges() > 0;
        }

        public Genres GetGenre(int id)
        {
            var genre = (
                from gnr in _dbContext.Genres
                where gnr.GenreId == id
                select gnr).FirstOrDefault();
            return genre;
        }

        public List<Genres> GetGenres()
        {
            List<Genres> genres = (
                from gnr in _dbContext.Genres
                select gnr).ToList();
            return genres;
        }

        public bool InsertGenre(Genres genre)
        {
            _dbContext.Add(genre);
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateGenre(Genres genre)
        {
            _dbContext.Entry(genre).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
