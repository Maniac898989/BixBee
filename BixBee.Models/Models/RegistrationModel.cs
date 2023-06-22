using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Models.Models
{
    public class RegistrationModel
    {
        [Required, MaxLength(11, ErrorMessage ="Please enter your 11 digit phone number")]
        public string Phone { get; set; }
        [Required, EmailAddress(ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Password is required"), MinLength(6, ErrorMessage = "Password must be atleast 6 characters long")]
        public string Password { get; set; }
    }
}
