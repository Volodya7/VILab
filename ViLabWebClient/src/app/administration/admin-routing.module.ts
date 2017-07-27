import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AdminComponent } from './admin.component';
import { AdminCasesComponent } from './admin-cases/admin-cases.component';
import { AdminCategoriesComponent } from './admin-categories/admin-categories.component';
import { UsersComponent } from './users/users.component';
import { ContactsComponent } from './contacts/contacts.component';



import { AuthGuard } from '../guards/auth-guard.service';

const adminRoutes: Routes = [
  {
    path: 'admin', component: AdminComponent, canActivate: [AuthGuard], canActivateChild: [AuthGuard], children: [
      { path: '', component: DashboardComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'cases', component: AdminCasesComponent },
      { path: 'categories', component: AdminCategoriesComponent },
      { path: 'users', component: UsersComponent },
      { path: 'contacts', component: ContactsComponent }
    ]
  },
  { path: 'login', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(adminRoutes)],
  exports: [RouterModule]
})

export class AdminRoutingModule { }

export const adminRoutableComponents = [
  LoginComponent,
  DashboardComponent,
  AdminComponent,
  AdminCasesComponent,
  AdminCategoriesComponent,
  UsersComponent,
  ContactsComponent
];