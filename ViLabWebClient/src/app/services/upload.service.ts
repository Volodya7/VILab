import { Injectable } from "@angular/core";
import { Http, Headers } from "@angular/http";

declare var $: any;

@Injectable()
export class FormsHttpClient {
  requestUrl: string;
  responseData: any;
  handleError: any;

  constructor(private http: Http
  ) {
    this.http = http;
  }

  postWithFile(url: string, postData: any, files: File[]) {

  }
}