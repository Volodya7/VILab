import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";

declare var $: any;

@Injectable()
export class HttpClient123 {
  requestUrl: string;
  responseData: any;
  handleError: any;

  constructor(private http: Http
  ) {
    this.http = http;
  }

  postWithFile(url: string, postData: any, files: File[]) {

    let headers = new Headers();
    let formData: FormData = new FormData();
    //formData.append('files', files[0], files[0].name);
    // For multiple files
     for (let i = 0; i < files.length; i++) {
         formData.append(`files[]`, files[i], files[i].name);
     }

    if (postData !== "" && postData !== undefined && postData !== null) {
      for (var property in postData) {
        if (postData.hasOwnProperty(property)) {
          formData.append(property, postData[property]);
        }
      }
    }
    var returnReponse = new Promise((resolve, reject) => {
      this.http.post("http://localhost:59451/api/cases", formData, {
        headers: headers
      }).subscribe(
        res => {
          this.responseData = res.json();
          resolve(this.responseData);
        },
        error => {
          reject(error);
        }
      );
    });
    return returnReponse;
  }
}