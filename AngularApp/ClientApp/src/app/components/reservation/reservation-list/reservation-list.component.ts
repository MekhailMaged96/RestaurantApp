import { LocalizationService } from './../../../services/localization/localization.service';
import { Component, OnInit } from '@angular/core';
import { ReservationService } from 'src/app/services/reservation/reservation.service';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.scss']
})
export class ReservationListComponent implements OnInit {

  ListOfReservations;
  constructor(private reservationService:ReservationService,public localization:LocalizationService) { }

  ngOnInit() {
    this.GetAll();
  }

  GetAll(){

    this.reservationService.GetAll().subscribe(response => {
this.ListOfReservations = response;
    })
  }
}
