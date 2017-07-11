import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ImageUploadModule } from 'angular2-image-upload';
import { FormsHttpClient } from 'app/services/upload.service';
import { AppRoutingModule, routableComponents } from './app-routing.module';

@NgModule({
    declarations: [
      AppComponent,
      routableComponents
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        ImageUploadModule.forRoot(),
        AppRoutingModule
    ],
    providers: [FormsHttpClient],
    bootstrap: [AppComponent]
})
export class AppModule { }
