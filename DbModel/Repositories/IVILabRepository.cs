using System;
using System.Collections.Generic;
using System.Text;
using DbModel.Entities;

namespace DbModel.Repositories
{
  public interface IVILabRepository
  {
    void AddCategory(Category category);
    IEnumerable<Category> GetCategories();
    void DeleteCategory(int id);

    void AddSubcategory(Subcategory subcategory);
    void DeleteSubcategory(int id);
    bool Save();
  }
}
