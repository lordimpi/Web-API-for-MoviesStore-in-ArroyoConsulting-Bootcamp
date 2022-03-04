using DataAccess.Models;
using DataAccess.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    public interface IActorsDataAccess
    {
        List<Actors> GetActors();
        Actors GetActor(int id);
        bool InsertActor(Actors actor);
        bool UpdateActor(Actors actor);
        bool DeleteActor(int id);
    }
}
