import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions, RequestMethod, Request, Response } from "@angular/http";
import 'rxjs/Rx';


@Injectable()
export class RestService {
  baseUrl: string = "https://localhost:44351/api/";

  constructor(private http: Http
  ) {
    this.http = http;
  }

  POST(url: string, postData: any) {
    var headers = new Headers(), authtoken = localStorage.getItem('authtoken');

    headers.append("Content-Type", 'application/json');
    headers.append("Accept", 'application/json');

    if (authtoken) {
      headers.append("Authorization", 'Bearer ' + authtoken);
    }


    var requestoptions = new RequestOptions({
      method: RequestMethod.Post,
      url: this.baseUrl + url,
      headers: headers,
      body: postData
    });

    return this.http.request(new Request(requestoptions))
      .map((res: Response) => {
        if (res) {
          return { status: res.status, json: res.json() }
        }
      });
  }
}