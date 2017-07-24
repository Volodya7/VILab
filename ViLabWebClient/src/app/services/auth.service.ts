import { Injectable } from "@angular/core";
import { RestService } from './rest.service';
import { Observable } from 'rxjs/Rx';

declare var $: any;

@Injectable()
export class AuthService {
  constructor(private restService: RestService) {
    this.restService = restService;
  }

  login(username: string, password: string) {
    var returnPromise = new Promise((resolve, reject) => {
      this.restService.POST("auth/token",
        {
          "username": username,
          "password": password
        }).subscribe(data => {
          resolve(data);
        }, error => {
          reject(error);
        });
    });

    return returnPromise;
  }
}