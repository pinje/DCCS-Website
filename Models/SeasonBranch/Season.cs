using System.ComponentModel.DataAnnotations;

namespace Models.SeasonBranch
{
    public class Season
    {
        private int seasonId;
        private int seasonNumber;
        private int splitNumber;
        private string seasonName;
        private SeasonType type;
        private DateTime? startDate;
        private DateTime? endDate;
        private SeasonStage stage;
        private SeasonStatus status;
        private int registrationStatus;
        private string hubId;

        public Season()
        {

        }

        public Season(int seasonId, int seasonNumber, int splitNumber, string seasonName, SeasonType type,
            DateTime? startDate, DateTime? endDate, SeasonStage stage, SeasonStatus status, int registrationStatus, string hubId)
        {
            this.seasonId = seasonId;
            this.seasonNumber = seasonNumber;
            this.splitNumber = splitNumber;
            this.seasonName = seasonName;
            this.type = type;
            this.startDate = startDate;
            this.endDate = endDate;
            this.stage = stage;
            this.status = status;
            this.registrationStatus = registrationStatus;
            this.hubId = hubId;
        }

        public Season(int seasonNumber, int splitNumber, string seasonName, SeasonType type,
            DateTime? startDate, DateTime? endDate, SeasonStage stage, SeasonStatus status, int registrationStatus, string hubId)
        {
            this.seasonNumber = seasonNumber;
            this.splitNumber = splitNumber;
            this.seasonName = seasonName;
            this.type = type;
            this.startDate = startDate;
            this.endDate = endDate;
            this.stage = stage;
            this.status = status;
            this.registrationStatus = registrationStatus;
            this.hubId = hubId;
        }

        public int SeasonId { get { return seasonId; } set { seasonId = value; } }
        public int SeasonNumber { get { return seasonNumber; } set { seasonNumber = value; } }
        public int SplitNumber { get { return splitNumber; } set { splitNumber = value; } }
        [Required(ErrorMessage = "Season Name: Field required")]
        [StringLength(50, ErrorMessage = "Tournament Name: Max 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Season Name: Only letters and numbers allowed")]
        public string SeasonName { get { return seasonName; } set { seasonName = value; } }
        public SeasonType Type { get { return type; } set { type = value; } }
        public DateTime? StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime? EndDate { get { return endDate; } set { endDate = value; } }
        public SeasonStage Stage { get { return stage; } set { stage = value; } }
        public SeasonStatus Status { get { return status; } set { status = value; } }
        public int RegistrationStatus { get { return registrationStatus; } set { registrationStatus = value; } }
        [Required(ErrorMessage = "FACEIT HUB Id: Field required")]
        [StringLength(100, ErrorMessage = "Tournament Name: Max 100 characters")]
        public string HubId { get { return hubId; } set { hubId = value; } }
    }
}