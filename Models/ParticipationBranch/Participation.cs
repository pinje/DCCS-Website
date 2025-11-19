using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ParticipationBranch
{
    public class Participation
    {
        private int participationId;
        private int teamId;
        private int tournamentId;
        private string status;

        public Participation() { }

        public Participation(int participationId, int teamId, int tournamentId, string status)
        {
            this.participationId = participationId;
            this.teamId = teamId;
            this.tournamentId = tournamentId;
            this.status = status;
        }

        public Participation(int teamId, int tournamentId, string status)
        {
            this.teamId = teamId;
            this.tournamentId = tournamentId;
            this.status = status;
        }

        public int ParticipationId { get { return participationId; } set { participationId = value; } }
        public int TeamId { get { return teamId; } set { teamId = value; } }
        public int TournamentId { get { return tournamentId; } set { tournamentId = value; } }
        public string Status { get { return status; } set { status = value;} }
    }
}
