using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;

namespace VILab.API.Services.S3Service
{
    public interface IS3Service
    {
        string UploadFile(IFormFile file);
    }
}
