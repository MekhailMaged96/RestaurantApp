import { DataService } from './../http/data.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

constructor(private dataService:DataService) { }


  login(data){

    return this.dataService.Create('/account/login',data,"application/json");
  }

  register(data){

    return this.dataService.Create('/account/register',data,"application/json");
  }

}
