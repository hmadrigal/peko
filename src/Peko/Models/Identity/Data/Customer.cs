using System;
using System.Collections.Generic;
using System.Text;

namespace Peko.Models.Identity.Data
{
    public class Customer
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string MobilePhone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; }

    }
}
