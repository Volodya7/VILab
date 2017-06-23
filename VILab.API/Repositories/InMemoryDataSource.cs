using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VILab.API.Models;
using VILab.API.Models.Retrieve;

namespace VILab.API.Repositories
{
    public class InMemoryDataSource
    {
        public static InMemoryDataSource Current { get; } = new InMemoryDataSource();

        public List<CityDto> Cities { get; set; }

        public InMemoryDataSource()
        {
            Cities=new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Lviv",
                    Description = "Has a rubbish problems",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Lviv",
                            Description = "Has a rubbish problems"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Kyiv",
                            Description = "Main city"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "London",
                            Description = "The capital of Great Britain"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Kyiv",
                    Description = "Main city",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Lviv",
                            Description = "Has a rubbish problems"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Kyiv",
                            Description = "Main city"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "London",
                            Description = "The capital of Great Britain"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "London",
                    Description = "The capital of Great Britain",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Lviv",
                            Description = "Has a rubbish problems"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Kyiv",
                            Description = "Main city"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "London",
                            Description = "The capital of Great Britain"
                        }
                    }
                }
            };
        }
    }
}
