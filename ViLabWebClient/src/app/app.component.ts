import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient123 } from 'app/services/upload.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _httpService: Http, private _httpClient: HttpClient123) { }

  apiValues: object;
  files: File[] = [];

  ngOnInit() {

  }

  imageUploaded(event) {
    console.log(event);
    this.files.push(event.file);
  }

  save() {
    this._httpClient.postWithFile("", null, this.files).then(result => {
      console.log(result);
    });
  }
}
