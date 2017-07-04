import { Component,OnInit, ViewEncapsulation } from '@angular/core';
import { Http } from '@angular/http'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    constructor(private _httpService: Http) { }
    apiValues: object;
    ngOnInit() {
        this._httpService.get('http://localhost:59451/api/cases').subscribe(values => {
            this.apiValues = values.json();
        });
    }
}
