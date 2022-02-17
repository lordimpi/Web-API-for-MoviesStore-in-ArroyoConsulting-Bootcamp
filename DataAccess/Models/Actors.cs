using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Actors
    {
        [Key]
        public int ActorId { get; set; }
        public string FullName { get; set; }

        public Actors()
        {

        }
        public Actors(int actorId, string fullName)
        {
            ActorId = actorId;
            FullName = fullName;
        }
    }
}
