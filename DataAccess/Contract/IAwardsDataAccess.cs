using DataAccess.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
    public interface IAwardsDataAccess
    {
        bool DeleteAward(int id);
        Awards GetAward(int id);
        List<Awards> GetAwards();
        bool InsertAward(Awards awards);
        bool UpdateAward(Awards award);
    }
}
