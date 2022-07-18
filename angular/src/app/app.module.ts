import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AboutComponent } from './components/about/about.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatPaginatorModule } from '@angular/material/paginator';
import { CreateAndUpdateUserComponent } from './components/users-and-roles/create-and-update-user/create-and-update-user.component';
import { InquiryComponent } from './components/inquiry/inquiry.component';
import { PropertyComponent } from './components/property/property.component';
import { StatesComponent } from './components/states/states.component';
import { CityComponent } from './components/city/city.component';
import { RoleComponent } from './components/role/role.component';
import { CreateAndUpdateModalComponent } from './components/inquiry/create-and-update-modal/create-and-update-modal.component';
import { PropertyFormComponent } from './components/property/property-form/property-form.component';
import { StateFormComponent } from './components/states/state-form/state-form.component';
import { CityFormComponent } from './components/city/city-form/city-form.component';
import { RoleFormComponent } from './components/role/role-form/role-form.component';
import { UsersComponent } from './components/users-and-roles/users.component';
import { HomeComponent } from './components/home/home.component';
import { PropertyDetailsComponent } from './components/property/property-details/property-details.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    LoginComponent,
    UsersComponent,
    CreateAndUpdateUserComponent,
    InquiryComponent,
    PropertyComponent,
    StatesComponent,
    CityComponent,
    RoleComponent,
    CreateAndUpdateModalComponent,
    PropertyFormComponent,
    StateFormComponent,
    CityFormComponent,
    RoleFormComponent,
    PropertyDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatTableModule,
    MatDialogModule,
    MatInputModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatPaginatorModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }
