import { Router } from '@angular/router';
import { ReservationService } from './../../../services/reservation/reservation.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LocalizationService } from 'src/app/services/localization/localization.service';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.scss']
})
export class AddReservationComponent implements OnInit {
  addForm:FormGroup;
  foodTypes;
  constructor(private fb:FormBuilder,private reservationService:ReservationService,
    public localization:LocalizationService,
    private router:Router) { }

  ngOnInit() {
    this.CreateForm();
    this.GetFoodTypes();
  }
  CreateForm(){
    this.addForm = this.fb.group({
      tableNumber:['',Validators.required],
      numOfPeople:['',Validators.required],
      foodTypeId:['',Validators.required],
      notes:[''],
    
    })
  }
  get addFormControl () {
    
    return this.addForm.controls;
  }

  AddReservation(){
    this.addForm.get('tableNumber').setValue(Number(this.addForm.get('tableNumber').value));
    this.addForm.get('numOfPeople').setValue(Number(this.addForm.get('numOfPeople').value));
    this.addForm.get('foodTypeId').setValue(Number(this.addForm.get('foodTypeId').value));

    
    this.reservationService.Add(this.addForm.value).subscribe(response => {

      this.router.navigate(['reservation/list']);
 })
  }
  GetFoodTypes(){
    this.reservationService.GetFoodTypes().subscribe(response => {
      this.foodTypes=response;
      console.log(this.foodTypes);
    })
  }
  onCancel(){
    this.router.navigate(['reservation/list']);
  }
}
