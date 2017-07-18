import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';


import { AuthGuard } from '../services/auth-guard.service';

const adminRoutes: Routes = [
  { path: 'admin', component: DashboardComponent, canActivate: [AuthGuard], canActivateChild: [AuthGuard] },
  { path: 'login', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(adminRoutes)],
  exports: [RouterModule]
})

export class AdminRoutingModule { }

export const adminRoutableComponents = [
  LoginComponent,
  DashboardComponent
];