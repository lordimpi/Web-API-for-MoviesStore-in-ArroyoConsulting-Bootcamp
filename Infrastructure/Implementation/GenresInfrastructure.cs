using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class GenresInfrastructure : IGenresInfrastructure
    {
        private readonly IGenresDataAccess _genresDataAccess;

        public GenresInfrastructure(IGenresDataAccess genresDataAccess)
        {
            _genresDataAccess = genresDataAccess;
        }

        public List<GenresDTO> GetGenres()
        {
            List<Genres> genres = _genresDataAccess.GetGenres();
            List<GenresDTO> genresDTOs = (
                from g in genres
                select new GenresDTO
                {
                    Genre = g.Genre
                }).ToList();
            return genresDTOs;
        }

        public GenresDTO GetGenre(int id)
        {
            Genres genre = _genresDataAccess.GetGenre(id);
            GenresDTO genreDTO = new()
            {
                Genre = genre.Genre
            };
            return genreDTO;
        }

        public bool InsertGenre(GenresInsertDTO genreDTO)
        {
            Genres genre = new()
            {
                Genre = genreDTO.Genre
            };
            return _genresDataAccess.InsertGenre(genre);
        }

        public bool UpdateGenre(GenresUpdateDTO genreDTO)
        {

            Genres genre = new()
            {
                GenreId = genreDTO.GenreId,
                Genre = genreDTO.Genre
            };
            return _genresDataAccess.UpdateGenre(genre);
        }

        public bool DeleteGenre(int id)
        {
            return _genresDataAccess.DeleteGenre(id);
        }
    }
}
