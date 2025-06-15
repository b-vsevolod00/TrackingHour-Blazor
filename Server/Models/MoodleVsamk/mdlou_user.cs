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

        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("@odata.etag")]
        public string ETag
        {
            get;
            set;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [ConcurrencyCheck]
        public string auth { get; set; }

        [ConcurrencyCheck]
        public bool confirmed { get; set; }

        [ConcurrencyCheck]
        public bool policyagreed { get; set; }

        [ConcurrencyCheck]
        public bool deleted { get; set; }

        [ConcurrencyCheck]
        public bool suspended { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long mnethostid { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string username { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string password { get; set; }

        [ConcurrencyCheck]
        public string idnumber { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string firstname { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string lastname { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string email { get; set; }

        [ConcurrencyCheck]
        public bool emailstop { get; set; }

        [ConcurrencyCheck]
        public string phone1 { get; set; }

        [ConcurrencyCheck]
        public string phone2 { get; set; }

        [ConcurrencyCheck]
        public string institution { get; set; }

        [ConcurrencyCheck]
        public string department { get; set; }

        [ConcurrencyCheck]
        public string address { get; set; }

        [ConcurrencyCheck]
        public string city { get; set; }

        [ConcurrencyCheck]
        public string country { get; set; }

        [ConcurrencyCheck]
        public string lang { get; set; }

        [ConcurrencyCheck]
        public string calendartype { get; set; }

        [ConcurrencyCheck]
        public string theme { get; set; }

        [ConcurrencyCheck]
        public string timezone { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long firstaccess { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long lastaccess { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long lastlogin { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long currentlogin { get; set; }

        [ConcurrencyCheck]
        public string lastip { get; set; }

        [ConcurrencyCheck]
        public string secret { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long picture { get; set; }

        [ConcurrencyCheck]
        public string description { get; set; }

        [ConcurrencyCheck]
        public sbyte descriptionformat { get; set; }

        [ConcurrencyCheck]
        public bool mailformat { get; set; }

        [ConcurrencyCheck]
        public bool maildigest { get; set; }

        [ConcurrencyCheck]
        public sbyte maildisplay { get; set; }

        [ConcurrencyCheck]
        public bool autosubscribe { get; set; }

        [ConcurrencyCheck]
        public bool trackforums { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timecreated { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timemodified { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long trustbitmask { get; set; }

        [ConcurrencyCheck]
        public string imagealt { get; set; }

        [ConcurrencyCheck]
        public string lastnamephonetic { get; set; }

        [ConcurrencyCheck]
        public string firstnamephonetic { get; set; }

        [ConcurrencyCheck]
        public string middlename { get; set; }

        [ConcurrencyCheck]
        public string alternatename { get; set; }

        [ConcurrencyCheck]
        public string moodlenetprofile { get; set; }

        public ICollection<mdlou_teacher_hour> mdlou_teacher_hours { get; set; }

        public ICollection<mdlou_teacher_hours_summary> mdlou_teacher_hours_summaries { get; set; }

        public ICollection<mdlou_teacher_workload> mdlou_teacher_workloads { get; set; }
    }
}