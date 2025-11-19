using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserBranch
{
    public class User
    {
        private int userId;
        private string discordId;
        private string discordTag;
        private string steamId;
        private string discordName;
        private string ign;
        private string teamId;
        private string status;
        private string firstname;
        private string lastname;
        private DateTime? birthday;
        private string country;
        private string university;
        private string studies;
        private string faceitURL;
        private string role;
        private string aspectRatio;
        private string resolution;
        private string scalingMode;
        private string mouse;
        private string dpi;
        private string sensitivity;
        private string zoomSensitivity;
        private string crosshair;

        public User() { }

        public User(int userId, string discordId, string discordTag, string discordName, string ign, string firstname, string lastname, DateTime? birthday, string country, string university, string studies, string faceitURL, string role, string aspectRatio, string resolution, string scalingMode, string mouse, string dpi, string sensitivity, string zoomSensitivity, string crosshair)
        {
            this.userId = userId;
            this.discordId = discordId;
            this.discordTag = discordTag;
            this.discordName = discordName;
            this.ign = ign;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.country = country;
            this.university = university;
            this.studies = studies;
            this.faceitURL = faceitURL;
            this.role = role;
            this.aspectRatio = aspectRatio;
            this.resolution = resolution;
            this.scalingMode = scalingMode;
            this.mouse = mouse;
            this.dpi = dpi;
            this.sensitivity = sensitivity;
            this.zoomSensitivity = zoomSensitivity;
            this.crosshair = crosshair;
        }

        public User(string discordId, string steamId, string discordTag, string discordName, string ign, string teamId, string status, string firstname, string lastname, DateTime? birthday, string country, string university, string studies, string faceitURL, string role, string aspectRatio, string resolution, string scalingMode, string mouse, string dpi, string sensitivity, string zoomSensitivity, string crosshair)
        {
            this.discordId = discordId;
            this.steamId = steamId;
            this.discordTag = discordTag;
            this.discordName = discordName;
            this.ign = ign;
            this.teamId = teamId;
            this.status = status;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.country = country;
            this.university = university;
            this.studies = studies;
            this.faceitURL = faceitURL;
            this.role = role;
            this.aspectRatio = aspectRatio;
            this.resolution = resolution;
            this.scalingMode = scalingMode;
            this.mouse = mouse;
            this.dpi = dpi;
            this.sensitivity = sensitivity;
            this.zoomSensitivity = zoomSensitivity;
            this.crosshair = crosshair;
        }

        public User(string discordId, string steamId, string discordTag, string discordName, string ign, string firstname, string lastname, DateTime? birthday, string university, string faceitURL)
        {
            this.discordId = discordId;
            this.steamId = steamId;
            this.discordTag = discordTag;
            this.discordName = discordName;
            this.ign = ign;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.university = university;
            this.faceitURL = faceitURL;
        }

        public User(string discordId, string ign)
        {
            this.discordId = discordId;
            this.ign = ign;
        }

        public User(string discordId, string ign, string status)
        {
            this.discordId = discordId;
            this.ign = ign;
            this.status = status;
        }

        public User(string discordId, string discordTag, string discordName, string status, string firstname, string lastname, DateTime? birthday, string university)
        {
            this.discordId = discordId;
            this.discordTag = discordTag;
            this.discordName = discordName;
            this.status = status;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthday = birthday;
            this.university = university;
        }

        public int UserId { get { return userId; } set { userId = value; } }
        public string DiscordId { get { return discordId; } set { discordId = value; } }
        public string SteamId { get { return steamId; } set { steamId = value; } }
        public string DiscordTag { get { return discordTag; } set { discordTag = value; } }
        public string DiscordName { get { return discordName; } set { discordName= value; } }
        public string Ign { get { return ign; } set { ign = value; } }
        public string TeamId { get { return teamId; } set { teamId = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Lastname { get { return lastname; } set { lastname = value; } }
        public DateTime? Birthday { get { return birthday; } set { birthday = value; } }
        public string Country { get { return country; } set { country = value; } }
        public string University { get { return university; } set { university = value; } }
        public string Studies { get { return studies; } set { studies = value; } }
        public string FaceitURL { get { return faceitURL; } set { faceitURL = value; } }
        public string Role { get { return role; } set { role = value; } }
        public string AspectRatio { get { return aspectRatio; } set { aspectRatio = value; } }
        public string Resolution { get { return resolution; } set { resolution = value; } }
        public string ScalingMode { get { return scalingMode; } set { scalingMode = value; } }
        public string Mouse { get { return mouse; } set { mouse = value; } }
        public string Dpi { get { return dpi; } set { dpi = value; } }
        public string Sensitivity { get { return sensitivity; } set { sensitivity = value; } }
        public string ZoomSensitivity { get { return zoomSensitivity; } set { zoomSensitivity = value; } }
        public string Crosshair { get { return crosshair; } set { crosshair = value; } }
    }
}
