using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VILab.API.Dto.Create
{
    public class CaseForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();
    }
}
