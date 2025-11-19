using DAL.InvitationBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class InvitationManager
    {
        IInvitationDA invitation;

        public InvitationManager(IInvitationDA invitation)
        {
            this.invitation = invitation;
        }

        public void Invite(string discordId, string teamId)
        {
            this.invitation.Invite(discordId, teamId);
        }

        public List<string> GetInvitations(string discordId)
        {
            return this.invitation.GetInvitations(discordId);
        }

        public void Delete(string discordId, string teamId)
        {
            this.invitation.Delete(discordId, teamId);
        }

        public void DeleteByUser(string discordId)
        {
            this.invitation.DeleteByUser(discordId);
        }
    }
}
