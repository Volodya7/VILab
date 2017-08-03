using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VILab.API.Services.S3Service;

namespace VILab.API.Dto.Create
{
  public class CaseForCreationDto
  {
    public string Name { get; set; }
    public string Subname { get; set; }
    public string Description { get; set; }
    public IFormFile BeforeImage { get; set; }
    public IFormFile AfterImage { get; set; }
    public int CategoryId { get; set; }
    public int SubcategoryId { get; set; }
    public string BeforeImgUrl { get; set; }
    public string AfterImgUrl { get; set; }
  }
}
