using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Amazon.S3;
using DbModel.Entities;
using DbModel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VILab.API.Dto.Create;
using VILab.API.Dto.Retrieve;
using VILab.API.Services.S3Service;

namespace VILab.API.Controllers
{
  [Authorize(Policy = "SuperUsers")]
  [EnableCors("SiteCorsPolicy")]
  [Route("api/cases")]
  public class CasesController : Controller
  {
    private IS3Service _s3Service;
    private IVILabRepository _vilabRepository;

    public CasesController(IS3Service s3Service, IVILabRepository viLabRepository)
    {
      _s3Service = s3Service;
      _vilabRepository = viLabRepository;
    }

    [HttpGet]
    public IActionResult GetCases()
    {
      var testCases = new List<CaseDto>
            {
                new CaseDto
                {
                    Name = "First case",
                    Description = "Description for first case",
                    ImgUrl = "www.firstcase.com"
                },
                new CaseDto
                {
                    Name = "Second case",
                    Description = "Description for second case",
                    ImgUrl = "www.firstcase.com"
                },
                new CaseDto
                {
                    Name = "Third case",
                    Description = "Description for third case",
                    ImgUrl = "www.firstcase.com"
                },
                new CaseDto
                {
                    Name = "Forth case",
                    Description = "Description for forth case",
                    ImgUrl = "www.firstcase.com"
                }
            };
      return Ok(testCases);
    }

    [HttpPost]
    public IActionResult CreateCase(CaseForCreationDto caseForCreationDto)
    {
      if (!ModelState.IsValid || caseForCreationDto == null)
      {
        return BadRequest(ModelState);
      }

      caseForCreationDto.BeforeImgUrl = caseForCreationDto.BeforeImage != null ? _s3Service.UploadFile(caseForCreationDto.BeforeImage) : string.Empty;
      caseForCreationDto.AfterImgUrl = caseForCreationDto.AfterImage != null ? _s3Service.UploadFile(caseForCreationDto.AfterImage) : string.Empty;

      var caseToSave = new Case();
      AutoMapper.Mapper.Map(caseForCreationDto, caseToSave);

      _vilabRepository.AddCase(caseToSave);

      if (!_vilabRepository.Save())
      {
        return BadRequest($"Failed to create case {caseForCreationDto.Name}");
      }

      return Ok();
    }
  }
}
