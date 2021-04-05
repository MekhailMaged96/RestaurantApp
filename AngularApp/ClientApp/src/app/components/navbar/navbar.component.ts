import { LocalizationService } from './../../services/localization/localization.service';
import { JwtService } from './../../services/jwt/jwt.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  navbarOpen: boolean = false;
  selectedLang;
  constructor(public _auth:JwtService,private router:Router,private translate:TranslateService ,
    public localization:LocalizationService) { }

  ngOnInit() {
    this.selectedLang= this.localization.GetLang();
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }
  onLangChange(lang){
    this.localization.setLang(lang);
  }
  logout(){
    this._auth.logout();
    this.router.navigate(['/home']);
  }


 
}
