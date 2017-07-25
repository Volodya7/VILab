import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Http } from '@angular/http';
import { FormsHttpClient } from 'app/services/upload.service';
import { Case } from 'app/models/case';

@Component({
  selector: 'app-root',
  templateUrl: './admin-cases.html'
})
export class AdminCasesComponent implements OnInit {
  constructor(private _httpService: Http, private _httpClient: FormsHttpClient) { }

  apiValues: object;
  files: File[] = [];
  model = new Case();

  ngOnInit() {

  }

  imageUploaded(event) {
    this.files.push(event.file);
  }

  save() {
    this._httpClient.postWithFile("", this.model, this.files).then(result => {
      console.log(result);
    });
  }
}
