using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookListMVCWith_identity.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string city { get; set; }
        public string FullName { get; set; }

    }
}
