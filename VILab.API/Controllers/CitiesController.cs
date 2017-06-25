using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VILab.API.Models.Retrieve;
using VILab.API.Repositories;
using VILab.API.Services;

namespace VILab.API.Controllers
{
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
