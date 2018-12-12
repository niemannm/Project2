using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter a user email")]
        [DisplayName("User Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}