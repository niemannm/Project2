using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("Missions")]
    public class Missions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MissionID { get; set; }

        [Required(ErrorMessage = "Please enter a mission name")]
        [DisplayName("Mission Name")]
        public string MissionName { get; set; }

        [Required(ErrorMessage = "Please enter a mission president's name")]
        [DisplayName("President's Name")]
        public string PresidentName { get; set; }

        [Required(ErrorMessage = "Please enter an address")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Please enter a language")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Please enter climate")]
        public string Climate { get; set; }

        [Required(ErrorMessage = "Please enter dominant Religion")]
        public string DominantReligion { get; set; }

        [Required(ErrorMessage = "Please enter flag img path")]
        public string FlagImagePath { get; set; }
    }
}