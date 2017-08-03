import { Injectable } from '@angular/core';
import { RestService } from 'app/services/rest.service';
import { CreateCategory } from 'app/models/admin/create/createCategory';
import { CreateSubcategory } from 'app/models/admin/create/createSubcategory';
import { CreateCase } from 'app/models/admin/create/createCase';

@Injectable()
export class CategoryService {
  constructor(private restService: RestService) {
    this.restService = restService;
  }

  baseCategoryUrl: string = "categories";
  baseSubcategoryUrl: string = "subcategories";
  baseCaseUrl: string = "cases";

  createCategory(category: CreateCategory) {
    return this.restService.POSTWithFile(this.baseCategoryUrl, category, category.Image);
  }

  getCategories() {

    var returnPromise = new Promise((resolve, reject) => {
      this.restService.GET(this.baseCategoryUrl).subscribe(data => {

        if (data.status === 200) {
          resolve(data.json);
        }

        reject("bad request");
      },
        error => {
          reject(error);
        });
    });

    return returnPromise;
  }

  deleteCategory(id: number) {
    return this.restService.DELETE(this.baseCategoryUrl, id);
  }

  createSubcategory(subcategory: CreateSubcategory) {
    return this.restService.POST(this.baseSubcategoryUrl, subcategory);
  }

  getSubcategoriesForCategory(categoryId: number) {
    var returnPromise = new Promise((resolve, reject) => {
      this.restService.GET(this.baseSubcategoryUrl + "/" + categoryId).subscribe(data => {

        if (data.status === 200) {
          resolve(data.json);
        }

        reject("bad request");
      },
        error => {
          reject(error);
        });
    });

    return returnPromise;
  }

  deleteSubcategory(id: number) {
    return this.restService.DELETE(this.baseSubcategoryUrl, id);
  }

  createCase(caseModel: CreateCase) {
    console.log(caseModel);
    return this.restService.POSTWithFile(this.baseCaseUrl, caseModel, null);
  }
}
