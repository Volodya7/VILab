import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './main/home/home.component';
import { CaseComponent } from './main/case/case.component';
import {CasesComponent} from './main/cases/cases.component';
import {ContactsComponent} from './main/contacts/contacts.component';
import {GalleryComponent} from './main/gallery/gallery.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'case', component: CaseComponent },
  { path: 'cases', component: CasesComponent },
  { path: 'contacts',  component: ContactsComponent },
  { path: 'gallery', component: GalleryComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }

export const routableComponents = [
  HomeComponent,
  CaseComponent,
  CasesComponent,
  ContactsComponent,
  GalleryComponent
];