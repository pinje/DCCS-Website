using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.TeamBranch;
using Models.UserBranch;

namespace DAL.TeamBranch
{
    public interface ITeamDA
    {
        void AddTeam(Team team);
        string GetTeamName(string teamId);
        List<User> GetTeamMembers(string teamId);
        List<Team> GetTeamsOwned(string discordId);
        string GetCaptainId(string teamId);
        bool TeamExists(string teamId);
        string GetTeamId(string discordId, string teamName);
        List<string> GetTeamNames();
        void Delete(string teamId);
        Team GetTeam(string teamId);
    }
}
