using DAL.ParticipationBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ParticipationBranch;

namespace DLL
{
    public class ParticipationManager
    {
        IParticipationDA participation;

        public ParticipationManager(IParticipationDA participation)
        {
            this.participation = participation;
        }

        public void AddParticipation(Participation participation)
        {
            this.participation.AddParticipation(participation);
        }
        
        public List<Participation> GetParticipations()
        {
            return this.participation.GetParticipations();
        }
        
        public void UpdateStatus(int participationId)
        {
            this.participation.UpdateStatus(participationId);
        }

        public void Delete(int participationId)
        {
            this.participation.Delete(participationId);
        }

        public string GetStatus(string teamId, int seasonId)
        {
            return this.participation.GetStatus(teamId, seasonId);
        }

        public void DeleteByTeam(string teamId)
        {
            this.participation.DeleteByTeam(teamId);
        }

        public List<Participation> GetParticipants(int seasonId)
        {
            return this.participation.GetParticipants(seasonId);
        }
    }
}
