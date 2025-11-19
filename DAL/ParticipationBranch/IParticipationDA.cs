using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ParticipationBranch;

namespace DAL.ParticipationBranch
{
    public interface IParticipationDA
    {
        void AddParticipation(Participation participation);
        List<Participation> GetParticipations();
        void UpdateStatus(int participationId);
        void Delete(int participationId);   
        string GetStatus(string teamId, int seasonId);
        void DeleteByTeam(string teamId);
        List<Participation> GetParticipants(int seasonId);
    }
}
