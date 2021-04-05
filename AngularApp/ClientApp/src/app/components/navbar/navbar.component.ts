import { JwtService } from './../../services/jwt/jwt.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  navbarOpen: boolean = false;

  constructor(public _auth:JwtService,private router:Router) { }

  ngOnInit() {
  }

  toggleNavbar() {
    this.navbarOpen = !this.navbarOpen;
  }
  logout(){
    this._auth.logout();
    this.router.navigate(['/home']);
  }
}
