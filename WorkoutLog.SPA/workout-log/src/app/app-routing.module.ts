import { UserComponent } from './user/user.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { LandingComponent } from './landing/landing/landing.component';
import { AuthGuard } from './_auth/auth.guard';

const routes: Routes = [
    { path: '', component: UserComponent},
    { path: 'home', component: LandingComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
