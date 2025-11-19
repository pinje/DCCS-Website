using DAL.TeamBranch;
using Models.TeamBranch;
using Models.UserBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class TeamManager
    {
        ITeamDA team;

        public TeamManager(ITeamDA team)
        {
            this.team = team;
        }

        public void AddTeam(Team team)
        {
            this.team.AddTeam(team);
        }

        public string GetTeamName(string teamId)
        {
            return this.team.GetTeamName(teamId);
        }
        public List<User> GetTeamMembers(string teamId)
        {
            return this.team.GetTeamMembers(teamId);
        }

        public List<Team> GetTeamsOwned(string discordId)
        {
            return this.team.GetTeamsOwned(discordId);
        }

        public string GetCaptainId(string teamId)
        {
            return this.team.GetCaptainId(teamId);
        }

        public bool TeamExists(string teamId)
        {
            return this.team.TeamExists(teamId);
        }

        public string GetTeamId(string discord, string teamName)
        {
            return this.team.GetTeamId(discord, teamName);
        }

        public List<string> GetTeamNames() { return this.team.GetTeamNames();}

        public void Delete(string teamId)
        {
            this.team.Delete(teamId);
        }

        public Team GetTeam(string teamId)
        {
            return this.team.GetTeam(teamId);
        }
    }
}
