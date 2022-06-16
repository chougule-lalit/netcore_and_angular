import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginOrRegister = true;

  constructor() { }

  ngOnInit(): void {
  }

  toggleRegistration(){
    this.loginOrRegister = !this.loginOrRegister;
  }

}
