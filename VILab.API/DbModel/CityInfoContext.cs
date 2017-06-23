using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VILab.API.Entities;

namespace VILab.API.DbModel
{
    public class CityInfoContext: DbContext
    {

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterests { get; set; }
    }
}
