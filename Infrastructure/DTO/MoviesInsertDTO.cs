﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class MoviesInsertDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int RunningTime { get; set; }
        public DateTime Release { get; set; }
        public int GenreId { get; set; }
        public int AwardId { get; set; }
    }
}
