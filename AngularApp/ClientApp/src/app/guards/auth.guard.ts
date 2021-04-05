import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtService } from '../services/jwt/jwt.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth:JwtService,private router:Router) {
    

  }
  canActivate(): boolean{
    if(this.auth.LoggedIn()){
      return true;
    }
    this.router.navigate(['']);
    return false;
  }
  
}
