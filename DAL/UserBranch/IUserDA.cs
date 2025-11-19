using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.UserBranch;

namespace DAL.UserBranch
{
    public interface IUserDA
    {
        void AddUser(User user);
        bool AlreadyRegistered(string discordId);
        string UserStatus(string discordId);
        List<User> GetPendingUsers();
        List<User> GetFreeUsers();
        void UpdateAccepted(string discordId);
        void UpdateUserTeam(string discordId, string teamId);
        User GetUser(string discordId);
        void UpdateUserStatus(string discordId, string status);
        bool IsAdmin(string discordId);
        string GetUserTeamId(string discordId);
        void Delete(string discordId);
        bool IsCaptain(string discordId);

        List<User> GetUsersInTeam(string teamId);
    }
}