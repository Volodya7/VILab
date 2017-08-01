using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbModel.Entities;

namespace DbModel.Repositories
{
  public class VILabRepository : IVILabRepository
  {
    private ViLabContext _context;

    public VILabRepository(ViLabContext context)
    {
      _context = context;
    }


    public void AddCategory(Category category)
    {
      _context.Categories.Add(category);
    }

    public IEnumerable<Category> GetCategories()
    {
      return _context.Categories.ToList();
    }

    public void AddSubcategory(Subcategory subcategory)
    {
      _context.Subcategories.Add(subcategory);
    }

    public bool Save()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
