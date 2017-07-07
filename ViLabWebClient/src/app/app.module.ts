import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ImageUploadModule } from 'angular2-image-upload';
import { FormsHttpClient } from 'app/services/upload.service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
      HttpModule,
        ImageUploadModule.forRoot()
    ],
    providers: [FormsHttpClient],
    bootstrap: [AppComponent]
})
export class AppModule { }
