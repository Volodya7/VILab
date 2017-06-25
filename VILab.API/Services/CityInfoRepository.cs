using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VILab.API.DbModel;
using VILab.API.Entities;

namespace VILab.API.Services
{
    public class CityInfoRepository:ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c=>c.Name).ToList();
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public City GetCity(int cityId,bool includePointsOfInterests)
        {
            if (includePointsOfInterests)
            {
                return _context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);
            }

            return _context.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterest(int cityId)
        {
            return _context.PointsOfInterests.Where(p => p.CityId == cityId).ToList();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfinterestId)
        {
            return _context.PointsOfInterests
                .FirstOrDefault(p => p.CityId == cityId && p.Id == pointOfinterestId);
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public void DeletePointOfinterest(PointOfInterest pointOfinterest)
        {
            _context.PointsOfInterests.Remove(pointOfinterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool PointOfInterestExists(int pointOfinterestId)
        {
            return _context.PointsOfInterests.Any(p => p.Id == pointOfinterestId);
        }
    }
}
