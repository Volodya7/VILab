import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CasesComponent } from './administration/cases/cases.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent},
  { path: 'cases', component: CasesComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

export const routableComponents = [
  CasesComponent,
  HomeComponent
];