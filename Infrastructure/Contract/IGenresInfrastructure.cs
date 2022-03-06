using Infrastructure.DTO.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public interface IGenresInfrastructure
    {
        bool DeleteGenre(int id);
        GenresDTO GetGenre(int id);
        List<GenresDTO> GetGenres();
        bool InsertGenre(GenresInsertDTO genreDTO);
        bool UpdateGenre(GenresUpdateDTO genreDTO);
    }
}
