﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO.Movies
{
    public class MoviesUpdateDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int RunningTime { get; set; }
        public DateTime Release { get; set; }
        public int GenreId { get; set; }
        public int AwardId { get; set; }
    }
}
