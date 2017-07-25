export class UserInfo {
  public username: string;

  constructor(username?: string) {
    this.username = username;
  }

  copyInto(model) {

    this.username = model.username;
  }
}