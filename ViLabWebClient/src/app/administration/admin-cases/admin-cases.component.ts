import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Http } from '@angular/http';
import { RestService } from 'app/services/rest.service';
import { Case } from 'app/models/case';

@Component({
  selector: 'app-root',
  templateUrl: './admin-cases.html'
})
export class AdminCasesComponent implements OnInit {
  constructor(private _httpService: Http, private restService: RestService) { }

  apiValues: object;
  files: File[] = [];
  model = new Case();

  ngOnInit() {

  }

  imageUploaded(event) {
    this.files.push(event.file);
  }

  save() {
    this.restService.POSTWithFile("", this.model, this.files[0]).subscribe(result => {
      console.log(result);
    });
  }
}
