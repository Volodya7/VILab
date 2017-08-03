using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbModel.Entities;
using Microsoft.EntityFrameworkCore;

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
      return _context.Categories.Include(x=>x.Subcategories).ToList();
    }

    public void DeleteCategory(int id)
    {
      var categoryToDelete = _context.Categories.Include(c=>c.Subcategories).FirstOrDefault(c => c.Id == id);
      if (categoryToDelete != null && categoryToDelete.Subcategories.Count == 0)
      {
        _context.Categories.Remove(categoryToDelete);
      }
    }

    public void AddSubcategory(Subcategory subcategory)
    {
      _context.Subcategories.Add(subcategory);
    }

    public void DeleteSubcategory(int id)
    {
      var subcategoryToDelete = _context.Subcategories.FirstOrDefault(s => s.Id == id);
      if (subcategoryToDelete != null)
      {
        _context.Subcategories.Remove(subcategoryToDelete);
      }
    }

    public IEnumerable<Subcategory> GetSubcategories(int categoryId)
    {
      return _context.Subcategories.Where(s => s.CategoryId == categoryId).ToList();
    }

    public void AddCase(Case caseModel)
    {
      _context.Cases.Add(caseModel);
    }

    public bool Save()
    {
      return _context.SaveChanges() > 0;
    }
  }
}
