using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModel.Entities;
using DbModel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VILab.API.Dto.Create;
using VILab.API.Dto.Retrieve;
using VILab.API.Services.S3Service;

namespace VILab.API.Controllers
{
  [Authorize(Policy = "SuperUsers")]
  [EnableCors("SiteCorsPolicy")]
  [Route("api/categories")]
  public class CategoriesController : Controller
  {
    private IS3Service _s3Service;
    private IVILabRepository _viLabRepository;

    public CategoriesController(IS3Service s3Service, IVILabRepository viLabRepository)
    {
      _s3Service = s3Service;
      _viLabRepository = viLabRepository;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
      var categories = _viLabRepository.GetCategories();

      var categoriesToReturn = AutoMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

      return Ok(categoriesToReturn);
    }

    [HttpPost]
    public IActionResult CreateCategory(CategoryForCreationDto category)
    {
      if (!ModelState.IsValid || category == null)
      {
        return BadRequest(ModelState);
      }

      var categoryToSave=new Category();
      AutoMapper.Mapper.Map(category, categoryToSave);

      var imgUrl = _s3Service.UploadFile(category.Image);
      if (!string.IsNullOrEmpty(imgUrl))
      {
        categoryToSave.ImgUrl = imgUrl;
      }

      _viLabRepository.AddCategory(categoryToSave);


      if (!_viLabRepository.Save())
      {
        return BadRequest($"failed to create category {category.Name}");
      }

      return Ok($"successfully created category {category.Name}");
    }
  }
}
