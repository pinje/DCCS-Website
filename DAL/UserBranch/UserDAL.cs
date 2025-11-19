using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SeasonBranch;
using Models.TeamBranch;
using Models.UserBranch;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;

namespace DAL.UserBranch
{
    public class UserDAL : DAL, IUserDA
    {
        public void AddUser(User user)
        {
            string sql = "INSERT INTO users " +
                "(accepted, updated, discordId, steamId, discordTag, discordName, ign, teamId, status, firstname, lastname, birthday, country, " +
                "university, studies, faceitURL, role, aspectRatio, resolution, scalingMode, " +
                "mouse, dpi, sensitivity, zoomSensitivity, crosshairCode) VALUES " +
                "(@pending, @updated, @discordid, @steamid, @discordtag, @discordname, @ign, @team, @status, @firstname, @lastname, @birthday, @country, " +
                "@university, @studies, @faceit, @role, @aspectratio, @res, @scalingmode, " +
                "@mouse, @dpi, @sens, @zoomsens, @ch); ";
            
            DateTime dateTime= DateTime.Now;

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("pending", "pending"),
                new KeyValuePair<string, dynamic>("updated", dateTime),
                new KeyValuePair<string, dynamic>("discordid", user.DiscordId),
                new KeyValuePair<string, dynamic>("steamid", user.SteamId),
                new KeyValuePair<string, dynamic>("discordtag", user.DiscordTag),
                new KeyValuePair<string, dynamic>("discordname", user.DiscordName),
                new KeyValuePair<string, dynamic>("ign", user.Ign),
                new KeyValuePair<string, dynamic>("team", null),
                new KeyValuePair<string, dynamic>("status", "-"),
                new KeyValuePair<string, dynamic>("firstname", user.Firstname),
                new KeyValuePair<string, dynamic>("lastname", user.Lastname),
                new KeyValuePair<string, dynamic>("birthday", user.Birthday),
                new KeyValuePair<string, dynamic>("country", user.Country),
                new KeyValuePair<string, dynamic>("university", user.University),
                new KeyValuePair<string, dynamic>("studies", user.Studies),
                new KeyValuePair<string, dynamic>("faceit", user.FaceitURL),
                new KeyValuePair<string, dynamic>("role", user.Role),
                new KeyValuePair<string, dynamic>("aspectratio", user.AspectRatio),
                new KeyValuePair<string, dynamic>("res", user.Resolution),
                new KeyValuePair<string, dynamic>("scalingmode", user.ScalingMode),
                new KeyValuePair<string, dynamic>("mouse", user.Mouse),
                new KeyValuePair<string, dynamic>("dpi", user.Dpi),
                new KeyValuePair<string, dynamic>("sens", user.Sensitivity),
                new KeyValuePair<string, dynamic>("zoomsens", user.ZoomSensitivity),
                new KeyValuePair<string, dynamic>("ch", user.Crosshair)
            };

            ExecuteInsert(sql, parameters);
        }

        public bool AlreadyRegistered(string discordId)
        {
            string query = "SELECT discordId FROM users";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<string> ids = new List<string>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string id = data.Tables[0].Rows[row]["discordId"].ToString();

                ids.Add(id);
            }

            foreach(string id in ids)
            {
                if (id == discordId)
                {
                    return true;
                }
            }

            return false;
        }

        public string UserStatus(string discordId)
        {
            string query = "SELECT accepted FROM users WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            DataSet data = ExecuteSql(query, parameters);

            if (data.Tables[0].Rows.Count == 0)
            {
                return "missing";
            } else if (data.Tables[0].Rows[0]["accepted"].ToString() == "pending")
            {
                return "pending";
            } else
            {
                return "accepted";
            }
        }

        public List<User> GetPendingUsers()
        {
            string query = "SELECT discordId, steamId, discordTag, discordName, ign, firstname, lastname, birthday, university, faceitURL FROM users WHERE accepted = \"pending\"";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<User> users = new List<User>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string id = data.Tables[0].Rows[row]["discordId"].ToString();
                string steam = data.Tables[0].Rows[row]["steamId"].ToString();
                string tag = data.Tables[0].Rows[row]["discordTag"].ToString();
                string name = data.Tables[0].Rows[row]["discordName"].ToString();
                string ign = data.Tables[0].Rows[row]["ign"].ToString();
                string firstname = data.Tables[0].Rows[row]["firstname"].ToString();
                string lastname = data.Tables[0].Rows[row]["lastname"].ToString();
                DateTime birthday = Convert.ToDateTime(data.Tables[0].Rows[row]["birthday"]);
                string university = data.Tables[0].Rows[row]["university"].ToString();
                string url = data.Tables[0].Rows[row]["faceitURL"].ToString();

                users.Add(new User(id, steam, tag, name, ign, firstname, lastname, birthday, university, url));
            }

            return users;
        }

        public List<User> GetFreeUsers()
        {
            string query = "SELECT discordId, ign FROM users WHERE accepted = \"accepted\" AND teamId IS NULL";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            List<User> users = new List<User>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string id = data.Tables[0].Rows[row]["discordId"].ToString();
                string ign = data.Tables[0].Rows[row]["ign"].ToString();

                users.Add(new User(id, ign));
            }

            return users;
        }

        public User GetUser(string discordId)
        {
            string query = "SELECT discordId, steamId, discordTag, discordName, ign, teamId, status, firstname, lastname, birthday, country, university, studies, faceitURL, " +
                "role, aspectRatio, resolution, scalingMode, mouse, dpi, sensitivity, zoomSensitivity, crosshairCode FROM users WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            DataSet data = ExecuteSql(query, parameters);

            string id = data.Tables[0].Rows[0]["discordId"].ToString();
            string steam = data.Tables[0].Rows[0]["steamId"].ToString();
            string tag = data.Tables[0].Rows[0]["discordTag"].ToString();
            string name = data.Tables[0].Rows[0]["discordName"].ToString();
            string ign = data.Tables[0].Rows[0]["ign"].ToString();
            string teamid = data.Tables[0].Rows[0]["teamId"].ToString();
            string status = data.Tables[0].Rows[0]["status"].ToString();
            string firstname = data.Tables[0].Rows[0]["firstname"].ToString();
            string lastname = data.Tables[0].Rows[0]["lastname"].ToString();
            DateTime birthday = Convert.ToDateTime(data.Tables[0].Rows[0]["birthday"]);
            string country = data.Tables[0].Rows[0]["country"].ToString();
            string university = data.Tables[0].Rows[0]["university"].ToString();
            string studies = data.Tables[0].Rows[0]["studies"].ToString();
            string url = data.Tables[0].Rows[0]["faceitURL"].ToString();

            string role = data.Tables[0].Rows[0]["role"].ToString();
            string ratio = data.Tables[0].Rows[0]["aspectRatio"].ToString();
            string res = data.Tables[0].Rows[0]["resolution"].ToString();
            string scaling = data.Tables[0].Rows[0]["scalingMode"].ToString();

            string mouse = data.Tables[0].Rows[0]["mouse"].ToString();
            string dpi = data.Tables[0].Rows[0]["dpi"].ToString();
            string sens = data.Tables[0].Rows[0]["sensitivity"].ToString();
            string zoom = data.Tables[0].Rows[0]["zoomSensitivity"].ToString();
            string ch = data.Tables[0].Rows[0]["crosshairCode"].ToString();

            User user = new User(id, steam, tag, name, ign, teamid, status, firstname, lastname, birthday, country, university, studies, url, role, ratio, res, scaling, mouse, dpi, sens, zoom, ch);

            return user;
        }

        public void UpdateAccepted(string discordId)
        {
            string sql = "UPDATE users SET accepted = \"accepted\" WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void UpdateUserTeam(string discordId, string teamId)
        {
            string sql = "UPDATE users SET teamId = @teamid WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId),
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            ExecuteInsert(sql, parameters);
        }

        public void UpdateUserStatus(string discordId, string status)
        {
            string sql = "UPDATE users SET status = @status WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("status", status),
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            ExecuteInsert(sql, parameters);
        }

        public bool IsAdmin(string discordId)
        {
            string query = "SELECT discordId FROM admins WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            DataSet data = ExecuteSql(query, parameters);

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                if (discordId == data.Tables[0].Rows[row]["discordId"].ToString())
                {
                    return true;
                }
            }

            return false;
        }

        public string GetUserTeamId(string discordId)
        {
            string query = "SELECT teamId FROM users WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            DataSet data = ExecuteSql(query, parameters);
            string id;

            if (data.Tables[0].Rows.Count == 0)
            {
                id = "null";
            } else
            {
                id = data.Tables[0].Rows[0]["teamId"].ToString();
            }

            return id;
        }

        public void Delete(string discordId)
        {
            string query = "DELETE FROM users WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            ExecuteSql(query, parameters);
        }

        public bool IsCaptain(string discordId)
        {
            string query = "SELECT captainId FROM teams";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
            };

            DataSet data = ExecuteSql(query, parameters);

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                if (discordId == data.Tables[0].Rows[row]["captainId"].ToString())
                {
                    return true;
                }
            }

            return false;
        }

        public List<User> GetUsersInTeam(string teamId)
        {
            string query = "SELECT discordId, discordTag, discordName, status, firstname, lastname, birthday, university FROM users WHERE teamId = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<User> users = new List<User>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string id = data.Tables[0].Rows[row]["discordId"].ToString();
                string tag = data.Tables[0].Rows[row]["discordTag"].ToString();
                string name = data.Tables[0].Rows[row]["discordName"].ToString();
                string status = data.Tables[0].Rows[row]["status"].ToString();
                string firstname = data.Tables[0].Rows[row]["firstname"].ToString();
                string lastname = data.Tables[0].Rows[row]["lastname"].ToString();
                DateTime birthday = Convert.ToDateTime(data.Tables[0].Rows[row]["birthday"]);
                string university = data.Tables[0].Rows[row]["university"].ToString();

                users.Add(new User(id, tag, name, status, firstname, lastname, birthday, university));
            }

            return users;
        }
    }
}
