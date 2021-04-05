import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataService {

constructor(private http:HttpClient) { }


  get(url,contentType,authorization="") {
    let headers = this.setHeaders(contentType,authorization);
    return this.http.get(environment.siteurl + url,{headers:headers})
      .pipe(map(response => response));
  }

  Create(url, data,contentType,authorization="") {
    let headers = this.setHeaders(contentType,authorization);
    return this.http.post(environment.siteurl + url, data,{headers:headers})
      .pipe(map(response => response));
    }
    
  setHeaders(content,auth){
    let headers = new HttpHeaders();

    if(auth){
      headers = headers.set("Content-type",content)
                        .set("Authorization",auth);
    }else{
      headers = headers.set("Content-type",content);
    }
    return headers;
  }
}


