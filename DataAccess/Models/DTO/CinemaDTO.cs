using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.DTO
{
    public class CinemaDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public DateTime Release { get; set; }
        public string ReleaseShort { get; set; }
        public string Genre { get; set; }
        public string Award { get; set; }

    }
}
