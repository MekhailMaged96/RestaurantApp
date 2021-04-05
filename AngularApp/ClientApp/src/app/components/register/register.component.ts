import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm:FormGroup

  constructor(private accountService:AccountService,private router:Router) { }

  ngOnInit() {
    this.CreateForm();
  }

  CreateForm(){
    this.registerForm = new FormGroup({
      username: new FormControl('',Validators.required),
      password: new FormControl('',[Validators.required]),
    });
  }

  onSubmit(form:FormGroup){
  if(form.valid){
    this.accountService.register(form.value).subscribe(response => {
      let user:any = response;
      if(user){
        localStorage.setItem('token',user.token);
        this.router.navigate(['reservation/list']);
      }
  
    },error =>{

    })
  }
  }

}
