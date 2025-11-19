using Models.UserBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ParticipationBranch;
using System.Data;
using Models.TeamBranch;

namespace DAL.ParticipationBranch
{
    public class ParticipationDAL : DAL, IParticipationDA
    {
        public void AddParticipation(Participation participation)
        {
            string sql = "INSERT INTO participations " +
                "(teamId, tournamentId, status) VALUES " +
                "(@teamid, @tournamentid, @status); ";

            DateTime dateTime = DateTime.Now;

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", participation.TeamId),
                new KeyValuePair<string, dynamic>("tournamentid", participation.TournamentId),
                new KeyValuePair<string, dynamic>("status", participation.Status)
            };

            ExecuteInsert(sql, parameters);
        }

        public List<Participation> GetParticipations()
        {
            string query = "SELECT * FROM participations WHERE status = \"pending\"";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Participation> participations = new List<Participation>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt16(data.Tables[0].Rows[row]["id"]);
                int teamid = Convert.ToInt16(data.Tables[0].Rows[row]["teamId"]);
                int tournamentid = Convert.ToInt16(data.Tables[0].Rows[row]["tournamentId"]);
                string status = data.Tables[0].Rows[row]["status"].ToString();

                participations.Add(new Participation(id, teamid, tournamentid, status));
            }

            return participations;
        }

        public void UpdateStatus(int participationId)
        {
            string sql = "UPDATE participations SET status = @status WHERE id = @id";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("status", "accepted"),
                new KeyValuePair<string, dynamic>("id", participationId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void Delete(int participationId)
        {
            string query = "DELETE FROM participations WHERE id = @id";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("id", participationId)
            };

            ExecuteSql(query, parameters);
        }

        public string GetStatus(string teamId, int seasonId)
        {
            string query = "SELECT status FROM participations WHERE teamId = @team AND tournamentId = @tournament";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("team", teamId),
                new KeyValuePair<string, dynamic>("tournament", seasonId)
            };

            DataSet data = ExecuteSql(query, parameters);
            string status;

            if (data.Tables[0].Rows.Count == 0)
            {
                status = "";
            } else
            {
                status = data.Tables[0].Rows[0]["status"].ToString();
            }

            return status;
        }

        public void DeleteByTeam(string teamId)
        {
            string query = "DELETE FROM participations WHERE teamId = @id";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("id", teamId)
            };

            ExecuteSql(query, parameters);
        }

        public List<Participation> GetParticipants(int seasonId)
        {
            string query = "SELECT * FROM participations WHERE status = \"accepted\" AND tournamentId = @tournament";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("tournament", seasonId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Participation> participations = new List<Participation>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt16(data.Tables[0].Rows[row]["id"]);
                int teamid = Convert.ToInt16(data.Tables[0].Rows[row]["teamId"]);
                int tournamentid = Convert.ToInt16(data.Tables[0].Rows[row]["tournamentId"]);
                string status = data.Tables[0].Rows[row]["status"].ToString();

                participations.Add(new Participation(id, teamid, tournamentid, status));
            }

            return participations;
        }
    }
}
