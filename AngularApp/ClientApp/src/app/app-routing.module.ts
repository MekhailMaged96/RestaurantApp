import { AddReservationComponent } from './components/reservation/add-reservation/add-reservation.component';
import { ReservationListComponent } from './components/reservation/reservation-list/reservation-list.component';
import { HomeComponent } from './components/home/home.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'reservation/list',component:ReservationListComponent,canActivate:[AuthGuard]},
  {path:'reservation/add',component:AddReservationComponent,canActivate:[AuthGuard]},
  {path:'**',component:HomeComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
