export class Category {
  public Id:number;
  public Name: string;
  public Description: string;
  public ImgUrl: string;

  constructor(model, imgSize: number) {
    this.Id = model == null ? 0 : model.id;
    this.Name = model == null ? "" : model.name;
    this.Description = model == null ? "" : model.description;
    this.ImgUrl = model == null ? "" : model.imgUrl;
    if (this.ImgUrl != null) {
      this.ImgUrl = this.ImgUrl.replace("size", imgSize + "x" + imgSize);
    }
  }
}