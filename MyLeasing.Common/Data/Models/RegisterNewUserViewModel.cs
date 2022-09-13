using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyLeasing.Common.Data.Models
{
    public class RegisterNewUserViewModel
    {
            
            [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
            [Required] 
            public string Document { get; set; }


            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Username { get; set; }

            [Required]
            [MinLength(6)]
            public string Password { get; set; }

            [Required]
            [Compare("Password")]
            public string Confirm { get; set; }
        
    }
}
