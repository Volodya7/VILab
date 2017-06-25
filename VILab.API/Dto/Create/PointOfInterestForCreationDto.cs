using System.ComponentModel.DataAnnotations;

namespace VILab.API.Dto.Create
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50,ErrorMessage = "Max length is 50")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Max length is 200")]
        public string Description { get; set; }
    }
}
