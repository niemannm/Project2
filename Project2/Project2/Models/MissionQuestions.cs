using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("MissionQuestions")]
    public class MissionQuestions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MissionQuestionID { get; set; }

        //foreign key
        public int? MissionID { get; set; }
        public virtual Missions Mission { get; set; }

        //foreign key
        public int? UserID { get; set; }
        public virtual Users User { get; set; }

        [Required(ErrorMessage = "Please enter a question")]
        [DisplayName("Question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Please enter an answer")]
        [DisplayName("Answer")]
        public string Answer { get; set; }
    }
}