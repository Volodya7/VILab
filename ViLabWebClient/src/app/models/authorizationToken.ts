export class AuthToken {
  public token: string;
  public expiration: string;

  constructor(token?: string, expiration?: string) {
    this.token = token;
    this.expiration = expiration;
  }

  copyInto(model) {
    this.token = model.token;
    this.expiration = model.expiration;
  }
}