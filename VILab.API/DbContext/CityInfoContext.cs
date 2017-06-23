using Microsoft.EntityFrameworkCore;
using VILab.API.Entities;

namespace VILab.API.DbContext
{
    public class CityInfoContext: Microsoft.EntityFrameworkCore.DbContext
    {

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterests { get; set; }
    }
}
