using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;

namespace VILab.API.Controllers
{
    [Route("api/cases")]
    public class CasesController:Controller
    {
        private IAmazonS3 _s3Client;

        public CasesController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpGet]
        public async Task<IActionResult> GetCases()
        {
            var list =await _s3Client.ListBucketsAsync();

            return Ok(list);
        }
    }
}
