using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_teacher_hours_summary")]
    public partial class mdlou_teacher_hours_summary
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
        public sbyte month { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal actual_lecture_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal actual_practice_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal actual_lab_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal actual_consultation_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal actual_exam_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public decimal actual_total_hours { get; set; }

        [Required]
        [ConcurrencyCheck]
        public DateTime last_updated { get; set; }
    }
}