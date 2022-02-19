using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peko.Models.Identity.Data
{
    public class PekoDbContext : IdentityDbContext<PekoUser>
    {
        public PekoDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
