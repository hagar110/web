using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookListMVCWith_identity.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "please enter your password")]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { set; get; }


        [Required(ErrorMessage = "confirm password!")]
        [Display(Name = "confirm password")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage="Password does not match")]
        public string ConfirmPassword { set; get; }


        [Required(ErrorMessage = "please enter your email")]
        [EmailAddress]
        [Display(Name = "email")]
        public string email { set; get; }
       
        public string City { set; get; }
       
        public string FullName { set; get; }

    }
}
