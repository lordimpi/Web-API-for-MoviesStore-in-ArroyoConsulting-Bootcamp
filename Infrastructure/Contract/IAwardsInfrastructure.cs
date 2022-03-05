using DataAccess.Models.Tables;
using Infrastructure.DTO.Awards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contract
{
    public interface IAwardsInfrastructure
    {
        bool DeleteAward(int id);
        AwardsDTO GetAward(int id);
        List<AwardsDTO> GetAwards();
        bool InsertAward(AwardsInsertDTO awardsDTO);
        bool UpdateAward(AwardsUpdateDTO awardsDTO);
    }
}
