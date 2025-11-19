using DAL.SeasonBranch;
using Models.SeasonBranch;

namespace DLL
{
    public class SeasonManager
    {
        ISeasonDA season;

        public SeasonManager(ISeasonDA season)
        {
            this.season = season;
        }

        public void AddSeason(Season season)
        {
            this.season.AddSeason(season);
        }

        public void UpdateSeason(int seasonId, Season season)
        {
            this.season.UpdateSeason(seasonId, season);
        }

        public void DeleteSeason(int seasonId)
        {
            this.season.DeleteSeason(seasonId);
        }

        public Season GetSeason(int seasonId)
        {
            return this.season.GetSeason(seasonId);
        }

        public List<Season> GetAllSeasons()
        {
            return this.season.GetAllSeasons();
        }
    }
}