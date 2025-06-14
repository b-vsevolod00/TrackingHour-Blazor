using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_course")]
    public partial class mdlou_course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        public long category { get; set; }

        [Required]
        public long sortorder { get; set; }

        [Required]
        public string fullname { get; set; }

        [Required]
        public string shortname { get; set; }

        public string idnumber { get; set; }

        public string summary { get; set; }

        [Required]
        public sbyte summaryformat { get; set; }

        public string format { get; set; }

        public sbyte showgrades { get; set; }

        public int newsitems { get; set; }

        [Required]
        public long startdate { get; set; }

        [Required]
        public long enddate { get; set; }

        public bool relativedatesmode { get; set; }

        [Required]
        public long marker { get; set; }

        [Required]
        public long maxbytes { get; set; }

        [Required]
        public short legacyfiles { get; set; }

        [Required]
        public short showreports { get; set; }

        public bool visible { get; set; }

        public bool visibleold { get; set; }

        public bool? downloadcontent { get; set; }

        [Required]
        public short groupmode { get; set; }

        [Required]
        public short groupmodeforce { get; set; }

        [Required]
        public long defaultgroupingid { get; set; }

        public string lang { get; set; }

        public string calendartype { get; set; }

        public string theme { get; set; }

        [Required]
        public long timecreated { get; set; }

        [Required]
        public long timemodified { get; set; }

        public bool requested { get; set; }

        public bool enablecompletion { get; set; }

        public bool completionnotify { get; set; }

        [Required]
        public long cacherev { get; set; }

        public long? originalcourseid { get; set; }

        public bool showactivitydates { get; set; }

        public bool? showcompletionconditions { get; set; }
    }
}