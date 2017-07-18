import { Injectable } from "@angular/core";
import {
  CanActivate,
  CanActivateChild,
  Route,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot
} from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(private router: Router) { }

  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.canActivate(next, state);
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    //if (false) {
    //  return true;
    //}
    this.router.navigate(['/login'], { queryParams: { redirectTo: state.url } });
    return false;
  }

}