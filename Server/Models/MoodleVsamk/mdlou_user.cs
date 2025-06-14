using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_user")]
    public partial class mdlou_user
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string auth { get; set; }

        public bool confirmed { get; set; }

        public bool policyagreed { get; set; }

        public bool deleted { get; set; }

        public bool suspended { get; set; }

        [Required]
        public long mnethostid { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public string idnumber { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        public string email { get; set; }

        public bool emailstop { get; set; }

        public string phone1 { get; set; }

        public string phone2 { get; set; }

        public string institution { get; set; }

        public string department { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string lang { get; set; }

        public string calendartype { get; set; }

        public string theme { get; set; }

        public string timezone { get; set; }

        [Required]
        public long firstaccess { get; set; }

        [Required]
        public long lastaccess { get; set; }

        [Required]
        public long lastlogin { get; set; }

        [Required]
        public long currentlogin { get; set; }

        public string lastip { get; set; }

        public string secret { get; set; }

        [Required]
        public long picture { get; set; }

        public string description { get; set; }

        public sbyte descriptionformat { get; set; }

        public bool mailformat { get; set; }

        public bool maildigest { get; set; }

        public sbyte maildisplay { get; set; }

        public bool autosubscribe { get; set; }

        public bool trackforums { get; set; }

        [Required]
        public long timecreated { get; set; }

        [Required]
        public long timemodified { get; set; }

        [Required]
        public long trustbitmask { get; set; }

        public string imagealt { get; set; }

        public string lastnamephonetic { get; set; }

        public string firstnamephonetic { get; set; }

        public string middlename { get; set; }

        public string alternatename { get; set; }

        public string moodlenetprofile { get; set; }
    }
}