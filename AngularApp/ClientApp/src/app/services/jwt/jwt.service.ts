import { Injectable } from '@angular/core';
import { JwtHelperService } from "@auth0/angular-jwt";
@Injectable({
  providedIn: 'root'
})
export class JwtService {
  helper = new JwtHelperService();
constructor() { }


  LoggedIn(){
    let token =  localStorage.getItem('token');
    return !this.helper.isTokenExpired(token);
  }

 getToken(){
    let token = "Bearer " + localStorage.getItem('token');
    return token;
 }

 logout(){
  localStorage.removeItem('token');
 }
}
