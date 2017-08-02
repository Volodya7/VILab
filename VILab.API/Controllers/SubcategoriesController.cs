using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbModel.Entities;
using DbModel.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VILab.API.Dto.Create;

namespace VILab.API.Controllers
{
  [Authorize(Policy = "SuperUsers")]
  [EnableCors("SiteCorsPolicy")]
  [Route("api/subcategories")]
  public class SubcategoriesController : Controller
  {
    private IVILabRepository _vilabRepository;

    public SubcategoriesController(IVILabRepository viLabRepository)
    {
      _vilabRepository = viLabRepository;
    }

    [HttpPost]
    public IActionResult CreateSubcategory([FromBody]SubcategoryForCreationDto subcategory)
    {
      if (!ModelState.IsValid || subcategory == null)
      {
        return BadRequest(ModelState);
      }

      var subcategoryToSave=new Subcategory();
      AutoMapper.Mapper.Map(subcategory, subcategoryToSave);

      _vilabRepository.AddSubcategory(subcategoryToSave);

      if (!_vilabRepository.Save())
      {
        return BadRequest($"failed to create subcategory {subcategory.Name} ");
      }

      return Ok();
    }

    [HttpDelete("{subcategoryId}")]
    public IActionResult DeleteSubcategory(int subcategoryId)
    {
      if (subcategoryId > 0)
      {
        _vilabRepository.DeleteSubcategory(subcategoryId);
        if (!_vilabRepository.Save())
        {
          return BadRequest();
        }
        return Ok();
      }

      return BadRequest();
    }
  }
}
