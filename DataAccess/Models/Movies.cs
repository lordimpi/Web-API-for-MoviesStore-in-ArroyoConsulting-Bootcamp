using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RunningTime { get; set; }
        public DateTime Release { get; set; }
        public int GenreId { get; set; }

        public Movies()
        {

        }
        public Movies(int movieId, string title, string description,
            int runningTime, DateTime release, int genreId)
        {
            MovieId = movieId;
            Title = title;
            Description = description;
            RunningTime = runningTime;
            Release = release;
            GenreId = genreId;
        }
    }
}
