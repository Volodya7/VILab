using AutoMapper;
using DbModel.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using VILab.API.Dto.Retrieve;

namespace VILab.API.Controllers
{
    [Authorize]
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private ICityInfoRepository _cityInfoRepository;


        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var cityToReturn = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityWithPOI=Mapper.Map<CityDto>(cityToReturn);
                return Ok(cityWithPOI);
            }

            var cityWithoutPOI = Mapper.Map<CityWithoutPointsOfInterestDto>(cityToReturn);

            return Ok(cityWithoutPOI);
        }
    }
}
