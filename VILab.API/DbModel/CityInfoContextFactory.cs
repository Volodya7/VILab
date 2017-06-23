using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VILab.API.DbModel
{
    public class CityInfoContextFactory : IDbContextFactory<CityInfoContext>
    {
        public CityInfoContext Create(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CityInfoContext>();
            var connectionString = "Host=Localhost;Port=5432;Database=VILabDb;User Id='Volodya';Password='Volodya777';";
            optionsBuilder.UseNpgsql(connectionString);

            return new CityInfoContext(optionsBuilder.Options);
        }
    }
}
