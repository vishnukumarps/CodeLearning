
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
     public class User
    {
        [Key]
        public string  InternalUserId { get; set; }
        public string Name { get; set; }
        public string  Address { get; set; }
        
        public string Password { get; set; }

        public string Key { get; set; }
        
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }


    public class MyUserRole : IdentityRole
    {
        public string Description { get; set; }
    }

    public class MyUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; internal set; }
    }
}
