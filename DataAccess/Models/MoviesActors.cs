using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class MoviesActors
    {
        [Key]
        public int MovieActorId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public MoviesActors()
        {

        }
        public MoviesActors(int movieActorId, int movieId, int actorId)
        {
            MovieActorId = movieActorId;
            MovieId = movieId;
            ActorId = actorId;
        }
    }
}
