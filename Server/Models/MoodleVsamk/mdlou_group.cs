using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrackHourBlazor.Server.Models.moodle_vsamk
{
    [Table("mdlou_groups")]
    public partial class mdlou_group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        public long courseid { get; set; }

        public string idnumber { get; set; }

        [Required]
        public string name { get; set; }

        public string description { get; set; }

        [Required]
        public sbyte descriptionformat { get; set; }

        public string enrolmentkey { get; set; }

        [Required]
        public long picture { get; set; }

        [Required]
        public long timecreated { get; set; }

        [Required]
        public long timemodified { get; set; }
    }
}