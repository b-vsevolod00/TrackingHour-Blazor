using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_teacher_hours")]
    public partial class mdlou_teacher_hour
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
        public long teacher_id { get; set; }

        public mdlou_user teacher { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long course_id { get; set; }

        public mdlou_course course { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long group_id { get; set; }

        public mdlou_group group { get; set; }

        [Required]
        [ConcurrencyCheck]
        public DateTime lesson_date { get; set; }

        [Required]
        [ConcurrencyCheck]
        public TimeOnly start_time { get; set; }

        [Required]
        [ConcurrencyCheck]
        public TimeOnly end_time { get; set; }

        [ConcurrencyCheck]
        public decimal hours_count { get; set; }

        [Required]
        [ConcurrencyCheck]
        public sbyte lesson_type { get; set; }

        [ConcurrencyCheck]
        public string room { get; set; }

        [ConcurrencyCheck]
        public string topic { get; set; }

        [ConcurrencyCheck]
        public string notes { get; set; }

        [ConcurrencyCheck]
        public bool status { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long created_by { get; set; }

        [ConcurrencyCheck]
        public long? approved_by { get; set; }

        [ConcurrencyCheck]
        public DateTime? approved_at { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timecreated { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timemodified { get; set; }
    }
}