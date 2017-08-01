using System.ComponentModel.DataAnnotations;

namespace VILab.API.Dto.Create
{
  public class SubcategoryForCreationDto
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public int CategoryId { get; set; }
  }
}