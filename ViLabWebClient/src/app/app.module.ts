﻿import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ImageUploadModule } from 'angular2-image-upload';

import { FormsHttpClient } from './services/upload.service';
import { AuthGuard } from 'app/guards/auth-guard.service';
import { RestService } from './services/rest.service';
import { AuthService } from './services/auth.service';

import { AppRoutingModule, routableComponents } from './app-routing.module';
import { AdminRoutingModule, adminRoutableComponents, adminServices } from './administration/admin-routing.module';

const services = [FormsHttpClient, AuthGuard, RestService, AuthService];

@NgModule({
  declarations: [
    AppComponent,
    routableComponents,
    adminRoutableComponents
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ImageUploadModule.forRoot(),
    AdminRoutingModule,
    AppRoutingModule
  ],
  providers: [services, adminServices],
  bootstrap: [AppComponent]
})
export class AppModule { }
