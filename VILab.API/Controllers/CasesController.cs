using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Amazon.S3;
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
    [Authorize]
    [EnableCors("SiteCorsPolicy")]
    [Route("api/cases")]
    public class CasesController : Controller
    {
        private IHostingEnvironment _env;
        private IS3Service _s3Service;

        public CasesController(IHostingEnvironment env, IS3Service s3Service)
        {
            _env = env;
            _s3Service = s3Service;
        }

        [HttpGet]
        public IActionResult GetCases()
        {
            var testCases=new List<CaseDto>
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
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var response = _s3Service.UploadFile(file);
            }

            return Ok();
        }
    }
}
