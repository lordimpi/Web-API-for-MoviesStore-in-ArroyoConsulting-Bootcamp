using DataAccess.Contract;
using DataAccess.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class GenresDataAccess : IGenresDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public GenresDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
