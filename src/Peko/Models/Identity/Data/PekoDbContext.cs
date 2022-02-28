using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peko.Models.Identity.Data
{
    public class PekoDbContext : IdentityDbContext<PekoIdentityUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public PekoDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
