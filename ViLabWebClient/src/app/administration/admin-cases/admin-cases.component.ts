import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Case } from 'app/models/case';
import { Category } from 'app/models/admin/read/category';
import { Subcategory } from 'app/models/admin/read/subcategory';
import { CategoryService } from '../admin-categories/admin-category.service';
import { CreateCase } from 'app/models/admin/create/createCase';

@Component({
  selector: 'app-root',
  templateUrl: './admin-cases.html'
})
export class AdminCasesComponent implements OnInit {
  constructor(private categoryService: CategoryService) {
    this.categoryService = categoryService;
  }

  isCaseEditMode: boolean = false;
  caseModel = new CreateCase();

  categories: Category[] = [];
  subcategories: Subcategory[] = [];

  ngOnInit() {
    this.initDropdowns();
  }

  imageUploaded(event, identifier) {
    if (identifier === "before") {
      this.caseModel.BeforeImage = event.file;
    }
    else if (identifier === "after") {
      this.caseModel.AfterImage = event.file;
    }
  }

  initDropdowns() {
    this.categoryService.getCategories().then((data: Object[]) => {
      let receivedCategories: Category[] = [];
      if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
          receivedCategories.push(new Category(data[i], null));
        }
      }

      this.categories = receivedCategories;
    });
  }

  onCategoryChanged(selectedCategoryId) {
    this.categoryService.getSubcategoriesForCategory(selectedCategoryId).then((data: Object[]) => {
      let receivedSubcategories: Subcategory[] = [];
      if (data.length > 0) {
        for (var i = 0; i < data.length; i++) {
          receivedSubcategories.push(new Subcategory(data[i]));
        }
      }

      this.subcategories = receivedSubcategories;
    });

  }

  createCase() {
    this.categoryService.createCase(this.caseModel).subscribe(data => {
      console.log(data);
    });
  }
}
