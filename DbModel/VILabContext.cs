using System;
using System.Linq;
using DbModel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DbModel
{
    public class ViLabContext: IdentityDbContext<ApplicationUser>
    {

        public ViLabContext(DbContextOptions<ViLabContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
    }
}
