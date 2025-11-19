using Models.UserBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InvitationBranch
{
    public interface IInvitationDA
    {
        void Invite(string discordId, string teamId);
        List<string> GetInvitations(string discordId);
        void Delete(string discordId, string teamId);
        void DeleteByUser(string discordId);
    }
}
