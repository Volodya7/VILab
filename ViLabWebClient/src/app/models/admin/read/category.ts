export class Category {
  public Name: string;
  public Description: string;
  public ImgUrl: string;

  constructor(model) {
    this.Name = model == null ? "" : model.name;
    this.Description = model == null ? "" : model.description;
    this.ImgUrl = model == null ? "" : model.imgUrl;
  }
}