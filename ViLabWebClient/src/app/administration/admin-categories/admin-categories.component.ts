import { Component, OnInit } from '@angular/core';
import { CreateCategory } from 'app/models/admin/create/createCategory';
import { CategoryService } from './admin-category.service';
import { Category } from 'app/models/admin/read/category';

@Component({
  selector: 'app-root',
  templateUrl: './admin-categories.html'
})
export class AdminCategoriesComponent implements OnInit {
  constructor(private categoryService: CategoryService) {
    this.categoryService = categoryService;
  }

  //variables

  categoryModel: CreateCategory = new CreateCategory();
  isCategoryEditMode: boolean = false;
  categories: Category[] = [];


  //methods

  ngOnInit() {
    this.getCategories();
  }

  createCategoty() {
    console.log(this.categoryModel);

    this.categoryService.createCategory(this.categoryModel).subscribe(data => {
      console.log(data);
    });
  }

  imageUploaded(event) {
    this.categoryModel.Image = event.file;
  }

  getCategories() {
    this.categoryService.getCategories().then((data: Object[]) => {
      var imgSize = 300;
      if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
          this.categories.push(new Category(data[i], imgSize));
        }

        console.log(this.categories);
      }
    });
  }
}
