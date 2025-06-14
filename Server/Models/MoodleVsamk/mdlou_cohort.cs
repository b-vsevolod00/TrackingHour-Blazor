using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_cohort")]
    public partial class mdlou_cohort
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        public long contextid { get; set; }

        [Required]
        public string name { get; set; }

        public string idnumber { get; set; }

        public string description { get; set; }

        [Required]
        public sbyte descriptionformat { get; set; }

        public bool visible { get; set; }

        [Required]
        public string component { get; set; }

        [Required]
        public long timecreated { get; set; }

        [Required]
        public long timemodified { get; set; }

        public string theme { get; set; }
    }
}