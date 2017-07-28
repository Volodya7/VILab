import { Injectable } from "@angular/core";
import { RestService } from 'app/services/rest.service';
import { CreateCategory } from 'app/models/admin/create/createCategory';

@Injectable()
export class CategoryService {
  constructor(private restService: RestService) {
    this.restService = restService;
  }

  baseCategoryUrl:string="categories";

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
      }, error => {
        reject(error);
      });
    });

    return returnPromise;
  }
}