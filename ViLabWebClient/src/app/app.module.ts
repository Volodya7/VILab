import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ImageUploadModule } from 'angular2-image-upload';
import { HttpClient123 } from 'app/services/upload.service';

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
    providers: [HttpClient123],
    bootstrap: [AppComponent]
})
export class AppModule { }
