export class Subcategory {
  public id: number;
  public name: string;
  public categoryId: number;

  constructor(model) {
    this.id = model == null ? 0 : model.id;
    this.name = model == null ? "" : model.name;
    this.categoryId = model == null ? "" : model.categoryId;
  }
}