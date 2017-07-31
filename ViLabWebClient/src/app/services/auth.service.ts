import { Injectable } from "@angular/core";
import { RestService } from './rest.service';
import { UserInfo } from 'app/models/userInfo';
import { AuthToken } from 'app/models/authorizationToken';
import { Router } from '@angular/router';
import 'rxjs/Rx';


@Injectable()
export class AuthService {
  constructor(private restService: RestService, private router: Router) {
    this.restService = restService;

    this.getAuthToken();
  }

  currentUser: UserInfo;
  authToken: AuthToken;

  public redirectUrl: string = "admin";


  login(username: string, password: string) {
    var returnPromise = new Promise((resolve, reject) => {
      this.restService.POST("auth/token",
        {
          "username": username,
          "password": password
        }).subscribe(data => {
          var model = data.json;

          this.currentUser = new UserInfo(username);
          this.authToken = new AuthToken(model.token, model.expiration);
          localStorage.setItem('currentSession', JSON.stringify({ authToken: this.authToken, user: this.currentUser }));

          if (this.redirectUrl) {
            this.router.navigate([this.redirectUrl]);
            this.redirectUrl = null;
          }


          resolve(data);
        }, error => {
          reject(error);
        });
    });

    return returnPromise;
  }

  getAuthToken() {

    if (this.authToken == null) {
      let currentSession = JSON.parse(localStorage.getItem('currentSession'));
      if (currentSession != null) {
        this.authToken = new AuthToken();
        this.authToken.copyInto(currentSession.authToken);
      }
    }

    return this.authToken;
  }

  getCurrentUser() {
    if (this.currentUser == null) {
      var currentSession = JSON.parse(localStorage.getItem('currentSession'));
      this.currentUser = new UserInfo();
      this.currentUser.copyInto(currentSession.user);
    }

    return this.currentUser;
  }

  isLoggedIn() {
    if (this.authToken != null) {
      return true;
    }
    return false;
  }

  logout() {
    this.currentUser = null;
    this.authToken = null;
    localStorage.removeItem('currentSession');

    this.router.navigate(['/login']);
  }
}