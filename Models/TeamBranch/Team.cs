using Models.UserBranch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Models.TeamBranch
{
    public class Team
    {
        private int teamId;
        private string teamName;
        private string university;
        private string faceitURL;
        private string represent;
        private string associationName;
        private string captainId;

        public Team() { }

        public Team(int teamId, string teamName, string university, string faceitURL, string represent, string associationName, string captainId)
        {
            this.teamId = teamId;
            this.teamName = teamName;
            this.university = university;
            this.faceitURL = faceitURL;
            this.represent = represent;
            this.associationName = associationName;
            this.captainId = captainId;
        }

        public Team(string teamName, string university, string faceitURL, string represent, string associationName, string captainId)
        {
            this.teamName = teamName;
            this.university = university;
            this.faceitURL = faceitURL;
            this.represent = represent;
            this.associationName = associationName;
            this.captainId = captainId;
        }

        public Team(int teamId, string teamName)
        {
            this.teamId = teamId;
            this.teamName = teamName;
        }

        public int TeamId { get { return teamId; } set { teamId = value; } }
        public string TeamName { get { return teamName; } set { teamName = value; } }
        public string University { get { return university; } set { university = value; } }
        public string FaceitURL { get { return faceitURL; } set { faceitURL = value; } }
        public string Represent { get { return represent; } set { represent = value; } }
        public string AssociationName { get { return associationName; } set { associationName = value; } }
        public string CaptainId { get { return captainId; } set { captainId = value; } }
    }
}
