using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the PRPCUser class
    public class PRPCUser : IdentityUser
    {
        [PersonalData]
        public string FName { get; set; }
        [PersonalData]
        public string LName { get; set; }
        [PersonalData]
        public string Email { get; set; }
        [PersonalData]
        public string PhoneNumber { get; set; }
        [PersonalData]
        public string Address { get; set; }
        [PersonalData]
        public string City { get; set; }
        [PersonalData]
        public string State { get; set; }
        [PersonalData]
        public string Zip { get; set; }
    }
}
