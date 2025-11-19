using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SeasonBranch;

namespace DAL.SeasonBranch
{
    public interface ISeasonDA
    {
        void AddSeason(Season season);
        void UpdateSeason(int seasonId, Season season);
        void DeleteSeason(int seasonId);
        Season GetSeason(int seasonId);
        List<Season> GetAllSeasons();
    }
}
