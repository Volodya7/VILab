import { Injectable } from "@angular/core";
import { RestService } from 'app/services/rest.service';
import { CreateCategory } from 'app/models/admin/create/createCategory';
import { CreateSubcategory } from 'app/models/admin/create/createSubcategory';

@Injectable()
export class CategoryService {
  constructor(private restService: RestService) {
    this.restService = restService;
  }

  baseCategoryUrl: string = "categories";
  baseSubcategoryUrl:string="subcategories";

  createCategory(category: CreateCategory) {
    return this.restService.POSTWithFile(this.baseCategoryUrl, category, category.Image);
  }
  createSubcategory(subcategory: CreateSubcategory) {
    return this.restService.POST(this.baseSubcategoryUrl, subcategory);
  }

  getCategories() {

    var returnPromise = new Promise((resolve, reject) => {
      this.restService.GET(this.baseCategoryUrl).subscribe(data => {

        if (data.status === 200) {
          resolve(data.json);
        }

        reject("bad request");
      }, error => {
        reject(error);
      });
    });

    return returnPromise;
  }
  deleteCategory(id: number) {
    return this.restService.DELETE(this.baseCategoryUrl, id);
  }

  deleteSubcategory(id: number) {
    return this.restService.DELETE(this.baseSubcategoryUrl, id);
  }
}