using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class AwardsDataAccess : IAwardsDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public AwardsDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteAward(int id)
        {
            var award = _dbContext.Awards.Find(id);
            _dbContext.Remove(award);
            return _dbContext.SaveChanges() > 0;
        }
        public Awards GetAward(int id)
        {
            var award = (
                from act in _dbContext.Awards
                where act.AwardId == id
                select act).FirstOrDefault();
            return award;

        }
        public List<Awards> GetAwards()
        {
            List<Awards> awards = (
                from aw in _dbContext.Awards
                select aw).ToList();
            return awards;
        }
        public bool InsertAward(Awards awards)
        {
            _dbContext.Add(awards);
            return _dbContext.SaveChanges() > 0;
        }
        public bool UpdateAward(Awards award)
        {
            _dbContext.Entry(award).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
