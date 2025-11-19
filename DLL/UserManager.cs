using DAL.UserBranch;
using Models.UserBranch;

namespace DLL
{
    public class UserManager
    {
        IUserDA user;

        public UserManager(IUserDA user)
        {
            this.user = user;
        }

        public void AddUser(User user)
        {
            this.user.AddUser(user);
        }

        public bool AlreadyRegistered(string discordId)
        {
            return this.user.AlreadyRegistered(discordId);
        }

        public string UserStatus(string discordId)
        {
            return this.user.UserStatus(discordId);
        }

        public List<User> GetPendingUsers() { return this.user.GetPendingUsers();}

        public List<User> GetFreeUsers() { return this.user.GetFreeUsers(); }

        public void UpdateAccepted(string discordId) { this.user.UpdateAccepted(discordId); }
        public void UpdateUserTeam(string discordId, string teamId) { this.user.UpdateUserTeam(discordId, teamId); }    
        public User GetUser(string discordId)
        {
            return this.user.GetUser(discordId);
        }

        public void UpdateUserStatus(string discordId, string status) { this.user.UpdateUserStatus(discordId, status); }
        public bool IsAdmin(string discordid)
        {
            return this.user.IsAdmin(discordid);
        }

        public string GetUserTeamId(string discordid)
        {
            return this.user.GetUserTeamId(discordid);
        }

        public void Delete(string discordid)
        {
            this.user.Delete(discordid);
        }
        public bool IsCaptain(string discordid)
        {
            return this.user.IsCaptain(discordid);
        }

        public List<User> GetUsersInTeam(string teamid)
        {
            return this.user.GetUsersInTeam(teamid);
        }
    } 
}
