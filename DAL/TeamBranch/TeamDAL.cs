using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.TeamBranch;
using Models.UserBranch;

namespace DAL.TeamBranch
{
    public class TeamDAL : DAL, ITeamDA
    {
        public void AddTeam(Team team)
        {
            string sql = "INSERT INTO teams " +
                "(teamName, university, faceitURL, represent, associationName, captainId) VALUES " +
                "(@teamname, @university, @faceit, @represent, @association, @captainid);";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamname", team.TeamName),
                new KeyValuePair<string, dynamic>("university", team.University),
                new KeyValuePair<string, dynamic>("faceit", team.FaceitURL),
                new KeyValuePair<string, dynamic>("represent", team.Represent),
                new KeyValuePair<string, dynamic>("association", team.AssociationName),
                new KeyValuePair<string, dynamic>("captainid", team.CaptainId)
            };

            ExecuteInsert(sql, parameters);
        }

        public string GetTeamName(string teamId)
        {
            string query = "SELECT teamName FROM teams WHERE id = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            DataSet data = ExecuteSql(query, parameters);

            string team = data.Tables[0].Rows[0]["teamName"].ToString();

            return team;
        }

        public List<User> GetTeamMembers(string teamId)
        {
            string query = "SELECT discordId, ign, status FROM users WHERE teamId = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<User> users = new List<User>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string id = data.Tables[0].Rows[row]["discordId"].ToString();
                string ign = data.Tables[0].Rows[row]["ign"].ToString();
                string status = data.Tables[0].Rows[row]["status"].ToString();

                users.Add(new User(id, ign, status));
            }

            return users;
        }

        public List<Team> GetTeamsOwned(string discordId)
        {
            string query = "SELECT id, teamName FROM teams WHERE captainId = @captainid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("captainid", discordId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<Team> users = new List<Team>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                int id = Convert.ToInt32(data.Tables[0].Rows[row]["id"]);
                string name = data.Tables[0].Rows[row]["teamName"].ToString();

                users.Add(new Team(id, name));
            }

            return users;
        }

        public string GetCaptainId(string teamId)
        {
            string query = "SELECT captainId FROM teams WHERE id = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            DataSet data = ExecuteSql(query, parameters);

            string captainId = data.Tables[0].Rows[0]["captainId"].ToString();

            return captainId;
        }

        public bool TeamExists(string teamId)
        {
            string query = "SELECT id FROM teams WHERE id = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            DataSet data = ExecuteSql(query, parameters);

            if (data.Tables[0].Rows.Count > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string GetTeamId(string discordId, string teamName)
        {
            string query = "SELECT id FROM teams WHERE captainId = @captain AND teamName = @name";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("captain", discordId),
                new KeyValuePair<string, dynamic>("name", teamName)
            };

            DataSet data = ExecuteSql(query, parameters);

            string id = data.Tables[0].Rows[0]["id"].ToString();

            return id;
        }

        public List<string> GetTeamNames()
        {
            string query = "SELECT teamName FROM teams";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<string> teams = new List<string>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string name = data.Tables[0].Rows[row]["teamName"].ToString();

                teams.Add(name);
            }

            return teams;
        }

        public void Delete(string teamId)
        {
            string query = "DELETE FROM teams WHERE id = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            ExecuteSql(query, parameters);
        }

        public Team GetTeam(string teamId)
        {
            string query = "SELECT id, teamName, university, faceitURL, represent, associationName, captainId FROM teams WHERE id = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            DataSet data = ExecuteSql(query, parameters);

            int id = Convert.ToInt16(data.Tables[0].Rows[0]["id"].ToString());
            string name = data.Tables[0].Rows[0]["teamName"].ToString();
            string uni = data.Tables[0].Rows[0]["university"].ToString();
            string url = data.Tables[0].Rows[0]["faceitURL"].ToString();
            string represent = data.Tables[0].Rows[0]["represent"].ToString();
            string assoc = data.Tables[0].Rows[0]["associationName"].ToString();
            string captain = data.Tables[0].Rows[0]["captainId"].ToString();

            Team team = new Team(id, name, uni, url, represent, assoc, captain);

            return team;
        }
    }
}
