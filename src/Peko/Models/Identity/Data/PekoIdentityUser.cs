using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peko.Models.Identity.Data
{
    public class PekoIdentityUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string SecondName { get; set; }

        [PersonalData]
        public string LastName1 { get; set; }

        [PersonalData]
        public string LastName2 { get; set; }

    }
}
