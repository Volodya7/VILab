using System.Collections.Generic;
using System.Linq;
using DbModel.Entities;

namespace DbModel.Extensions
{
    public static class ViLabContextExtensions
    {
        public static void EnsureSeedDataForContext(this ViLabContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            
            var cities= new List<City>()
            {
                new City()
                {
                    Name = "Lviv",
                    Description = "Has a rubbish problems",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Kyiv",
                            Description = "Main city"
                        },
                        new PointOfInterest()
                        {
                            Name = "London",
                            Description = "The capital of Great Britain"
                        }
                    }
                },
                new City()
                {
                    Name = "Kyiv",
                    Description = "Main city",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Lviv",
                            Description = "Has a rubbish problems"
                        },
                        new PointOfInterest()
                        {
                            Name = "London",
                            Description = "The capital of Great Britain"
                        }
                    }
                },
                new City()
                {
                    Name = "London",
                    Description = "The capital of Great Britain",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Lviv",
                            Description = "Has a rubbish problems"
                        },
                        new PointOfInterest()
                        {
                            Name = "Kyiv",
                            Description = "Main city"
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
