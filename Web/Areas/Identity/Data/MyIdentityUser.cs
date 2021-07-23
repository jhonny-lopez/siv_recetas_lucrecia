using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.Data
{
    public class MyIdentityUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Image { get; set; }
    }
}
