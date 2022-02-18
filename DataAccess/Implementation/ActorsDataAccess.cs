using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class ActorsDataAccess : IActorsDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public ActorsDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool DeleteActor(int id)
        {
            var actor = _dbContext.Actors.Find(id);
            _dbContext.Remove(actor);
            return _dbContext.SaveChanges() > 0;
        }
        public Actors GetActor(int id)
        {
            var actor = (
                from act in _dbContext.Actors
                where act.ActorId == id
                select act).FirstOrDefault();
            return actor;

        }
        public List<Actors> GetActors()
        {
            List<Actors> actors = (
                from acts in _dbContext.Actors
                select acts).ToList();
            return actors;
        }
        public bool InsertActor(Actors actor)
        {
            _dbContext.Add(actor);
            return _dbContext.SaveChanges() > 0;
        }
        public bool UpdateActor(Actors actor)
        {
            _dbContext.Entry(actor).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
