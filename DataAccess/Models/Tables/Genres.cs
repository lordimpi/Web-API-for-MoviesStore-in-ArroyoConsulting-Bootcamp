using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Tables
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<Movies> Movies { get; set; }

        public Genres()
        {
            Movies = new HashSet<Movies>();
        }
        public Genres(int genreId, string genre)
        {
            GenreId = genreId;
            Genre = genre;
        }
    }
}
