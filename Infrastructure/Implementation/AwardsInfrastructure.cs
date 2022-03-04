using DataAccess.Contract;
using DataAccess.Implementation.Base;
using DataAccess.Models.Tables;
using Infrastructure.Contract;
using Infrastructure.DTO;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class AwardsInfrastructure : IAwardsInfrastructure
    {
        private readonly IAwardsDataAccess _awardsDataAccess;

        public AwardsInfrastructure(IAwardsDataAccess awardsDataAccess)
        {
            _awardsDataAccess = awardsDataAccess;
        }

        public AwardsDTO GetAward(int id)
        {
            Awards award = _awardsDataAccess.GetAward(id);
            AwardsDTO awardsDTO = new AwardsDTO
            {
                Title = award.AwardTitle
            };
            return awardsDTO;
        }

        public List<AwardsDTO> GetAwards()
        {
            List<Awards> awards = _awardsDataAccess.GetAwards();
            List<AwardsDTO> awardsDTOs = (from a in awards
                                          select new AwardsDTO
                                          {
                                              Title = a.AwardTitle.FormatText()
                                          }).ToList();

            //List<MoviesDTO> moviesDTO_Method = movies.Select(m => new MoviesDTO
            //{
            //    DescriptionMovie = m.Description,
            //    TitleMovie = m.Title,
            //    Release = m.Release.ToShortDate(),
            //    RunningTime = $"#{m.RunningTime} minutes"
            //}).ToList();

            return awardsDTOs;
        }

        public bool InsertAward(Awards award)
        {
            award.AwardTitle = award.AwardTitle.FormatText();
            return _awardsDataAccess.InsertAward(award);
        }

        public bool UpdateAward(Awards award)
        {
            award.AwardTitle = award.AwardTitle.FormatText();
            return _awardsDataAccess.UpdateAward(award);
        }
        public bool DeleteAward(int id)
        {
            return _awardsDataAccess.DeleteAward(id);
        }
    }
}
