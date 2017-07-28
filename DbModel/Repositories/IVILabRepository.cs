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
    bool Save();
  }
}
