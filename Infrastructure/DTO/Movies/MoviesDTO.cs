using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.Movies
{
    public class MoviesDTO
    {
        public string TitleMovie { get; set; }
        public string DescriptionMovie { get; set; }
        public string RunningTime { get; set; }
        public string Release { get; set; }
        public string Genre { get; set; }
        public string Award { get; set; }
    }
}
