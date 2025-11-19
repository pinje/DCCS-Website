using Models.UserBranch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InvitationBranch
{
    public class InvitationDAL : DAL, IInvitationDA
    {
        public void Invite(string discordId, string teamId)
        {
            string sql = "INSERT INTO invitations (discordId, teamId) VALUES (@discordid, @teamid);";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId),
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            ExecuteInsert(sql, parameters);
        }

        public List<string> GetInvitations(string discordId)
        {
            string query = "SELECT teamId FROM invitations WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            DataSet data = ExecuteSql(query, parameters);

            List<string> invitations = new List<string>();

            for (int row = 0; row < data.Tables[0].Rows.Count; row++)
            {
                string teamid = data.Tables[0].Rows[row]["teamId"].ToString();


                invitations.Add(teamid);
            }

            return invitations;
        }

        public void Delete(string discordId, string teamId)
        {
            string query = "DELETE FROM invitations WHERE discordId = @discordid AND teamId = @teamid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId),
                new KeyValuePair<string, dynamic>("teamid", teamId)
            };

            ExecuteSql(query, parameters);
        }

        public void DeleteByUser(string discordId)
        {
            string query = "DELETE FROM invitations WHERE discordId = @discordid";

            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
            {
                new KeyValuePair<string, dynamic>("discordid", discordId)
            };

            ExecuteSql(query, parameters);
        }
    }
}
