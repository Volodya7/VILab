import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ImageUploadModule } from 'angular2-image-upload';
import { FormsHttpClient } from 'app/services/upload.service';
import { AuthGuard} from 'app/services/auth-guard.service';

import { AppRoutingModule, routableComponents } from './app-routing.module';
import { AdminRoutingModule, adminRoutableComponents } from './administration/admin-routing.module';

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
    AppRoutingModule,
    AdminRoutingModule
  ],
  providers: [FormsHttpClient, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
