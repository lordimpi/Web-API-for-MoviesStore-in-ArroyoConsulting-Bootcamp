using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    public interface IGenresDataAccess
    {
        List<Genres> GetGenres();
        Genres GetGenre(int id);
        bool InsertGenre(Genres genre);
        bool UpdateGenre(Genres genre);
        bool DeleteGenre(int id);
    }
}
