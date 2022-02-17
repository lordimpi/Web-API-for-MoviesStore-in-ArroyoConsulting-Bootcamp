using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public Genres()
        {

        }
        public Genres(int genreId, string genre)
        {
            GenreId = genreId;
            Genre = genre;
        }
    }
}
