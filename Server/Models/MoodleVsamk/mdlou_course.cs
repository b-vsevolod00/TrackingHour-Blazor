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

        [Required]
        [ConcurrencyCheck]
        public long category { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long sortorder { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string fullname { get; set; }

        [Required]
        [ConcurrencyCheck]
        public string shortname { get; set; }

        [ConcurrencyCheck]
        public string idnumber { get; set; }

        [ConcurrencyCheck]
        public string summary { get; set; }

        [Required]
        [ConcurrencyCheck]
        public sbyte summaryformat { get; set; }

        [ConcurrencyCheck]
        public string format { get; set; }

        [ConcurrencyCheck]
        public sbyte showgrades { get; set; }

        [ConcurrencyCheck]
        public int newsitems { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long startdate { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long enddate { get; set; }

        [ConcurrencyCheck]
        public bool relativedatesmode { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long marker { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long maxbytes { get; set; }

        [Required]
        [ConcurrencyCheck]
        public short legacyfiles { get; set; }

        [Required]
        [ConcurrencyCheck]
        public short showreports { get; set; }

        [ConcurrencyCheck]
        public bool visible { get; set; }

        [ConcurrencyCheck]
        public bool visibleold { get; set; }

        [ConcurrencyCheck]
        public bool? downloadcontent { get; set; }

        [Required]
        [ConcurrencyCheck]
        public short groupmode { get; set; }

        [Required]
        [ConcurrencyCheck]
        public short groupmodeforce { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long defaultgroupingid { get; set; }

        [ConcurrencyCheck]
        public string lang { get; set; }

        [ConcurrencyCheck]
        public string calendartype { get; set; }

        [ConcurrencyCheck]
        public string theme { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timecreated { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timemodified { get; set; }

        [ConcurrencyCheck]
        public bool requested { get; set; }

        [ConcurrencyCheck]
        public bool enablecompletion { get; set; }

        [ConcurrencyCheck]
        public bool completionnotify { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long cacherev { get; set; }

        [ConcurrencyCheck]
        public long? originalcourseid { get; set; }

        [ConcurrencyCheck]
        public bool showactivitydates { get; set; }

        [ConcurrencyCheck]
        public bool? showcompletionconditions { get; set; }

        public ICollection<mdlou_teacher_hour> mdlou_teacher_hours { get; set; }

        public ICollection<mdlou_teacher_hours_summary> mdlou_teacher_hours_summaries { get; set; }

        public ICollection<mdlou_teacher_workload> mdlou_teacher_workloads { get; set; }
    }
}