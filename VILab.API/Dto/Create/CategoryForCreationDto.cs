using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VILab.API.Dto.Create
{
  public class CategoryForCreationDto
  {
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public IFormFile Image { get; set; }
  }
}
