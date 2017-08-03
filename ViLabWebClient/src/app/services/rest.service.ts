import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions, RequestMethod, Request, Response } from "@angular/http";
import 'rxjs/Rx';
import { AuthToken } from 'app/models/authorizationToken';


@Injectable()
export class RestService {
  baseUrl: string = "https://localhost:44351/api/";
  responseData: any;

  constructor(private http: Http) {
    this.http = http;
  }

  POST(url: string, postData: any) {
    var headers = this.populateHeaders();

    var requestoptions = new RequestOptions({
      method: RequestMethod.Post,
      url: this.baseUrl + url,
      headers: headers,
      body: postData,
    });

    return this.request(requestoptions);
  };

  //workaround until angular will start support multipart/form-data
  POSTWithFile(url: string, postData: any, file: File) {

    var headers = new Headers(), authtoken = this.getAuthToken();
    let formData: FormData = new FormData();
    //formData.append('Image', file, file.name);
    //// For multiple files
    ////for (let i = 0; i < files.length; i++) {
    ////    formData.append(`Files`, files[i], files[i].name);
    ////}

    if (authtoken) {
      headers.append("Authorization", 'Bearer ' + authtoken.token);
    }

    if (postData !== "" && postData !== undefined && postData !== null) {
      for (var property in postData) {
        if (postData.hasOwnProperty(property)) {
          formData.append(property, postData[property]);
        }
      }
    }

    return this.http.post(this.baseUrl + url, formData, {
      headers: headers
    }).map((res: Response) => {
      if (res) {
        return { status: res.status, json: res }
      }
    });
  }

  GET(url: string) {
    var headers = this.populateHeaders();

    var requestoptions = new RequestOptions({
      method: RequestMethod.Get,
      url: this.baseUrl + url,
      headers: headers
    });

    return this.request(requestoptions);
  }

  DELETE(url: string, id: number) {
    var headers = this.populateHeaders();
    var requestoptions = new RequestOptions({
      method: RequestMethod.Delete,
      url: this.baseUrl + url + "/" + id,
      headers: headers
    });

    return this.request(requestoptions);
  }


  //Helpers

  getAuthToken() {
    let currentSession = JSON.parse(localStorage.getItem('currentSession'));
    if (currentSession != null) {
      let authToken = new AuthToken();
      authToken.copyInto(currentSession.authToken);

      return authToken;
    }
    return null;
  }
  populateHeaders() {
    var headers = new Headers(), authtoken = this.getAuthToken();

    headers.append("Content-Type", 'application/json');
    headers.append("Accept", 'application/json');

    if (authtoken) {
      headers.append("Authorization", 'Bearer ' + authtoken.token);
    }

    return headers;
  }
  request(requestoptions: RequestOptions) {
    return this.http.request(new Request(requestoptions))
      .map(this.extractData);
  }
  extractData(res: Response) {
    return { status: res.status, json: res.text() ? res.json() : {} };
  }
}