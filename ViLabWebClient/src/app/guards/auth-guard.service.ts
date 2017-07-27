import { Injectable } from "@angular/core";
import {
  CanActivate,
  CanActivateChild,
  Route,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';

import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(private router: Router, private authService: AuthService) {
    this.authService = authService;
  }

  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.canActivate(next, state);
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let url: string = state.url;

    return this.checkLogin(url);
    //return true;
  }

  checkLogin(url: string): boolean {
    if (this.authService.isLoggedIn()) { return true; }

    this.authService.redirectUrl = url;

    this.router.navigate(['/login']);

    return false;
  }

}