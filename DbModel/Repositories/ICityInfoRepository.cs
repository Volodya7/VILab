using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModel.Entities;

namespace DbModel.Repositories
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        bool CityExists(int cityId);
        City GetCity(int cityId,bool includePointsOfInterest);
        IEnumerable<PointOfInterest> GetPointsOfInterest(int cityId);
        bool PointOfInterestExists(int pointOfinterestId);
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfinterestId);
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfinterest(PointOfInterest pointOfinterest);
        bool Save();
    }
}
