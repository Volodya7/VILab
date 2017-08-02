import { Subcategory } from './subcategory';

export class Category {
  public id: number;
  public name: string;
  public description: string;
  public imgUrl: string;
  public subcategories: Subcategory[] = [];

  constructor(model, imgSize: number) {
    this.id = model == null ? 0 : model.id;
    this.name = model == null ? "" : model.name;
    this.description = model == null ? "" : model.description;
    this.imgUrl = model == null ? "" : model.imgUrl;

    if (this.imgUrl != null) {
      this.imgUrl = this.imgUrl.replace("size", imgSize + "x" + imgSize);
    }

    this.populateSubcategories(model == null ? [] : model.subcategories);
  }

  populateSubcategories(subcategories: Object[]) {
    for (let i = 0; i < subcategories.length; i++) {
      this.subcategories.push(new Subcategory(subcategories[i]));
    }
  }
}