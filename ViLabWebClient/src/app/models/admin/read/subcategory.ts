export class Subcategory {
  public Id: number;
  public Name: string;
  public CategoryId: number;

  constructor(model) {
    this.Id = model == null ? 0 : model.id;
    this.Name = model == null ? "" : model.name;
    this.CategoryId = model == null ? "" : model.categoryId;
  }
}