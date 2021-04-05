import { Router } from '@angular/router';
import { AccountService } from './../../services/account/account.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup,Validators } from '@angular/forms';
import { LocalizationService } from 'src/app/services/localization/localization.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm:FormGroup

  constructor(private accountService:AccountService,private router:Router,
    public localization:LocalizationService) { }

  ngOnInit() {
    this.CreateForm();
  }

  CreateForm(){
    this.loginForm = new FormGroup({
      username: new FormControl('',Validators.required),
      password: new FormControl('',[Validators.required]),
    });
  }

  onSubmit(form:FormGroup){

  if(form.valid){
    
    this.accountService.login(form.value).subscribe(response => {
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
