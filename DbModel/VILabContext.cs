using System;
using System.Linq;
using DbModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbModel
{
    public class ViLabContext: DbContext
    {

        public ViLabContext(DbContextOptions<ViLabContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
