using DataAccess.Contract;
using DataAccess.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class ActorsDataAccess: IActorsDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public ActorsDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
