using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class ApplicationUser
    {
        public string UserName { get; set; }
        public string Email { get;set; }

        public static implicit operator IdentityUser(ApplicationUser v)
        {
            throw new NotImplementedException();
        }
    }
}
