using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.SeasonBranch;

namespace DAL.SeasonBranch
{
    public class SeasonDAL : DAL, ISeasonDA
    {
        public void AddSeason(Season season)
        {
            string sql = "INSERT INTO seasons (seasonNumber, splitNumber, name, type, startDate, endDate, stage, status, registrationStatus, hubId) VALUES (@seasonnumber, @splitnumber, @name, " +
                "@type, @start, @end, @stage, @status, @registration, @hubid); ";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("seasonnumber", season.SeasonNumber),
                new KeyValuePair<string, dynamic>("splitnumber", season.SplitNumber),
                new KeyValuePair<string, dynamic>("name", season.SeasonName),
                new KeyValuePair<string, dynamic>("type", season.Type),
                new KeyValuePair<string, dynamic>("start", season.StartDate),
                new KeyValuePair<string, dynamic>("end", season.EndDate),
                new KeyValuePair<string, dynamic>("stage", season.Stage),
                new KeyValuePair<string, dynamic>("status", season.Status),
                new KeyValuePair<string, dynamic>("registration", season.RegistrationStatus),
                new KeyValuePair<string, dynamic>("hubid", season.HubId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void UpdateSeason(int seasonId, Season season)
        {
            string sql = "UPDATE seasons SET seasonNumber = @seasonnumber, splitNumber = @splitnumber, name = @name, type = @type" +
                "startDate = @start, endDate = @end, stage = @stage, status = @status, registrationStatus = @registration, " +
                "hubId = @hubid WHERE id = @id";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("seasonnumber", season.SeasonNumber),
                new KeyValuePair<string, dynamic>("splitnumber", season.SplitNumber),
                new KeyValuePair<string, dynamic>("name", season.SeasonName),
                new KeyValuePair<string, dynamic>("type", season.Type),
                new KeyValuePair<string, dynamic>("start", season.StartDate),
                new KeyValuePair<string, dynamic>("end", season.EndDate),
                new KeyValuePair<string, dynamic>("stage", season.Stage),
                new KeyValuePair<string, dynamic>("status", season.Status),
                new KeyValuePair<string, dynamic>("registration", season.RegistrationStatus),
                new KeyValuePair<string, dynamic>("hubid", season.HubId),
                new KeyValuePair<string, dynamic>("id", season.SeasonId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void DeleteSeason(int seasonId)
        {
            string sql = "DELETE FROM seasons WHERE id = @id";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("id", seasonId)
            };

            ExecuteInsert(sql, parameters);
        }

        public Season GetSeason(int seasonId)
        {
            string sql = "SELECT id, seasonNumber, splitNumber, name, type, startDate, endDate, stage, status, registrationStatus, hubId " +
                "FROM seasons WHERE id = @id";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("id", seasonId)
            };

            DataSet data = ExecuteSql(sql, parameters);

            if (data != null)
            {
                int id = Convert.ToInt16(data.Tables[0].Rows[0]["id"]);
                int seasonnumber = Convert.ToInt16(data.Tables[0].Rows[0]["seasonNumber"]);
                int splitnumber = Convert.ToInt16(data.Tables[0].Rows[0]["splitNumber"]);
                string name = data.Tables[0].Rows[0]["name"].ToString();
                SeasonType type = (SeasonType)data.Tables[0].Rows[0]["type"];
                DateTime? startDate;
                DateTime? endDate;
                if (data.Tables[0].Rows[0]["startDate"] == DBNull.Value)
                {
                    startDate = null;
                } else
                {
                    startDate = Convert.ToDateTime(data.Tables[0].Rows[0]["startDate"]);
                }

                if (data.Tables[0].Rows[0]["endDate"] == DBNull.Value)
                {
                    endDate = null;
                } else
                {
                    endDate = Convert.ToDateTime(data.Tables[0].Rows[0]["endDate"]);
                }
                
                SeasonStage stage = (SeasonStage)data.Tables[0].Rows[0]["stage"];
                SeasonStatus status = (SeasonStatus)data.Tables[0].Rows[0]["status"];
                int registration = Convert.ToInt16(data.Tables[0].Rows[0]["registrationStatus"]);
                string hubid = data.Tables[0].Rows[0]["hubId"].ToString();

                Season season = new Season(id, seasonnumber, splitnumber, name, type, startDate, endDate, stage, status, registration, hubid);
                return season;
            }
            else
            {
                return null;
            }
        }

        public List<Season> GetAllSeasons()
        {
            string query = "SELECT * FROM seasons ORDER BY seasonNumber DESC, splitNumber DESC";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Season> seasonDetails = new List<Season>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int seasonid = Convert.ToInt16(data.Tables[0].Rows[row]["id"]);
                int seasonnumber = Convert.ToInt16(data.Tables[0].Rows[row]["seasonNumber"]);
                int splitnumber = Convert.ToInt16(data.Tables[0].Rows[row]["splitNumber"]);
                string name = data.Tables[0].Rows[row]["name"].ToString();
                SeasonType type = (SeasonType)data.Tables[0].Rows[row]["type"];
                DateTime? startDate;
                if(data.Tables[0].Rows[row]["startDate"] is DBNull)
                {
                    startDate = null;
                } else
                {
                    startDate = Convert.ToDateTime(data.Tables[0].Rows[row]["startDate"]);
                }

                DateTime? endDate;
                if(data.Tables[0].Rows[row]["endDate"] is DBNull)
                {
                    endDate = null;
                } else
                {
                    endDate = Convert.ToDateTime(data.Tables[0].Rows[row]["endDate"]);
                }

                SeasonStage stage = (SeasonStage)data.Tables[0].Rows[row]["stage"];
                SeasonStatus status = (SeasonStatus)data.Tables[0].Rows[row]["status"];
                int registration = Convert.ToInt16(data.Tables[0].Rows[row]["registrationStatus"]);
                string hubid = data.Tables[0].Rows[row]["hubId"].ToString();

                seasonDetails.Add(new Season(seasonid, seasonnumber, splitnumber, name, type, startDate, endDate, stage, status, registration, hubid));
            }

            return seasonDetails;
        }
    }
}
