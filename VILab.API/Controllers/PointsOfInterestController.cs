using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VILab.API.Models.Create;
using VILab.API.Models.Retrieve;
using VILab.API.Models.Update;
using VILab.API.Repositories;
using VILab.API.Services;

namespace VILab.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {

        #region Fields

        private ILogger<PointsOfInterestController> _logger;
        private IMailService _mailService;

        #endregion

        #region Constructors

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger,IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        #endregion

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                var city = InMemoryDataSource.Current.Cities.FirstOrDefault(x => x.Id == cityId);
                if (city == null)
                {
                    _logger.LogInformation($"city with id {cityId} not found");
                    return NotFound();
                }

                return Ok(city.PointsOfInterest);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.",e);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = InMemoryDataSource.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody]PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = InMemoryDataSource.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            // to be improved
            var maxPointOfInterestId = InMemoryDataSource.Current.Cities.SelectMany(x => x.PointsOfInterest)
                .Max(x => x.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId = cityId, id = finalPointOfInterest.Id },
                finalPointOfInterest);
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id,
            [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = InMemoryDataSource.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromDataSource = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (pointOfInterestFromDataSource == null)
            {
                return NotFound();
            }

            pointOfInterestFromDataSource.Name = pointOfInterest.Name;
            pointOfInterestFromDataSource.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{cityId}/pointsofinterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
            [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                return NotFound();
            }

            var city = InMemoryDataSource.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromDataSource = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (pointOfInterestFromDataSource == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromDataSource.Name,
                Description = pointOfInterestFromDataSource.Description
            };

            patchDoc.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(pointOfInterestToPatch);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromDataSource.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromDataSource.Description = pointOfInterestToPatch.Name;

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = InMemoryDataSource.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromDataSource = city.PointsOfInterest.FirstOrDefault(x => x.Id == id);
            if (pointOfInterestFromDataSource == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFromDataSource);

            _mailService.Send("POI deleted",$"POI id: {id} for city with id: {cityId}");

            return NoContent();
        }


    }
}
