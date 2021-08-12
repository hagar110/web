using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookListMVCWith_identity.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string email { set; get; }

        [Required]
        [Display(Name = "password")]
        [DataType(DataType.Password)]
        public string password { set; get; }

        public bool rememberme { set; get; }
        public string ReturnUrl { set; get; }
        public IList<AuthenticationScheme> ExternalLogin{ set; get; }
    }
}
