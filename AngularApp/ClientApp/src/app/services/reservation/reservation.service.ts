import { JwtService } from './../jwt/jwt.service';
import { Injectable } from '@angular/core';
import { DataService } from '../http/data.service';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

constructor(private dataService:DataService,private jwtService:JwtService) { }


  GetAll(){
    return this.dataService.get('/Reservation/GetAll',"application/json",this.jwtService.getToken());
  }

  Add(data){
      return this.dataService.Create('/Reservation/Add',data,"application/json",this.jwtService.getToken());
  }

  GetFoodTypes(){
    return this.dataService.get('/Reservation/GetFoodTypes',"application/json",this.jwtService.getToken());
  }
}