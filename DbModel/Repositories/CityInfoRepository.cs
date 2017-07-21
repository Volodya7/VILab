using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DbModel.Entities;

namespace DbModel.Repositories
{
    public class CityInfoRepository
    {
        private ViLabContext _context;

        public CityInfoRepository(ViLabContext context)
        {
            _context = context;
        }
        public IEnumerable<City> GetCities()
        {
            return null;
        }

        public bool CityExists(int cityId)
        {
            return false;
        }

        public City GetCity(int cityId,bool includePointsOfInterests)
        {

            return null;
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterest(int cityId)
        {
            return null;
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfinterestId)
        {
            return null;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
           
        }

        public void DeletePointOfinterest(PointOfInterest pointOfinterest)
        {
            
        }

        public bool Save()
        {
            return false;
        }

        public bool PointOfInterestExists(int pointOfinterestId)
        {
            return false;
        }
    }
}
