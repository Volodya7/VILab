import { Component, OnInit } from '@angular/core';
import { CreateCategory } from 'app/models/admin/create/createCategory';
import { CreateSubcategory } from 'app/models/admin/create/createSubcategory';
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
  subcategoryModel: CreateSubcategory = new CreateSubcategory();

  isCategoryEditMode: boolean = false;
  isSubcategoryEditMode: boolean = false;
  categories: Category[] = [];


  //methods

  ngOnInit() {
    this.getCategories();
  }

  createCategoty() {
    this.categoryService.createCategory(this.categoryModel).subscribe(data => {
      this.getCategories();
      this.isCategoryEditMode = false;
    });
  }

  createSubCategoty() {
    console.log(this.subcategoryModel);
    this.categoryService.createSubcategory(this.subcategoryModel).subscribe(data => {
      this.isSubcategoryEditMode = false;
      this.getCategories();
    });
  }

  imageUploaded(event) {
    this.categoryModel.Image = event.file;
  }

  getCategories() {
    this.categoryService.getCategories().then((data: Object[]) => {
      let imgSize = 300;
      let receivedCategories: Category[] = [];
      if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
          receivedCategories.push(new Category(data[i], imgSize));
        }
      }

      this.categories = receivedCategories;

      console.log(this.categories);
    });
  }

  deleteCategory(categoryId) {
    if (categoryId != null) {
      this.categoryService.deleteCategory(categoryId).subscribe(data => {
        console.log(data);
        this.getCategories();
      });
    }
  }

  deleteSubcategory(subcategoryId) {
    if (subcategoryId != null) {
      this.categoryService.deleteSubcategory(subcategoryId).subscribe(data => {
        console.log(data);
        this.getCategories();
      });
    }
  }
}
