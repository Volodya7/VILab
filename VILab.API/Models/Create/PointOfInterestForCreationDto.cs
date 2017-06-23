using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VILab.API.Models.Create
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
