import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { CityComponent } from './components/city/city.component';
import { HomeComponent } from './components/home/home.component';
import { InquiryComponent } from './components/inquiry/inquiry.component';
import { LoginComponent } from './components/login/login.component';
import { PropertyDetailsComponent } from './components/property/property-details/property-details.component';
import { PropertyComponent } from './components/property/property.component';
import { RoleComponent } from './components/role/role.component';
import { StatesComponent } from './components/states/states.component';
import { UsersComponent } from './components/users-and-roles/users.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { RoleGuard } from './shared/guards/role.guard';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'about', component: AboutComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: 'users', component: UsersComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: 'enquiry', component: InquiryComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: 'property', component: PropertyComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: 'property-list', component: PropertyDetailsComponent, canActivate: [AuthGuard]},
  { path: 'states', component: StatesComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: 'city', component: CityComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: 'roles', component: RoleComponent, canActivate: [AuthGuard, RoleGuard], data: { expectedRoles: 1 } },
  { path: '**', redirectTo: 'dashboard' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
