using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_teacher_workload")]
    public partial class mdlou_teacher_workload
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
        public string academic_year { get; set; }

        [ConcurrencyCheck]
        public bool semester { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal planned_lecture_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal planned_practice_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal planned_lab_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal planned_consultation_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal planned_exam_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal planned_total_hours { get; set; }

        [ConcurrencyCheck]
        public string notes { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long created_by { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timecreated { get; set; }

        [Required]
        [ConcurrencyCheck]
        public long timemodified { get; set; }
    }
}