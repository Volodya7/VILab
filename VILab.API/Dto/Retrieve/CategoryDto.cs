﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VILab.API.Dto.Retrieve
{
  public class CategoryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public string ImgUrl { get; set; }

    public List<SubcategoryDto> Subcategories=new List<SubcategoryDto>();
  }
}
