import {Component, OnInit} from '@angular/core';
import {CommonService} from '../../shared/services/common.service';
import {AbstractControl, AbstractControlOptions, FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MustMatch} from 'src/app/shared/helpers/must-match-validators';
import {AuthService} from 'src/app/shared/services/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  userForm!: FormGroup;
  loginOrRegister = true;
  loginError = {status: false, message: ''};

  constructor(
    private commonService: CommonService,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    if (localStorage.getItem('user-details')) {
      this.router.navigate(['/home']);
    }
  }

  ngOnInit(): void {
    this.initLoginForm();
    this.initRegisterForm();
  }

  initLoginForm(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  initRegisterForm(): void {
    const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const phoneRegex = /^[0-9]{10}$/;
    const formOptions: AbstractControlOptions = {
      validators: MustMatch('password', 'conf_password')
    };

    this.userForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.pattern(emailRegex)]],
      phone: ['', [Validators.required, Validators.pattern(phoneRegex)]],
      roleId: ['', [Validators.required]],
      password: ['', [Validators.required]],
      conf_password: ['', [Validators.required]],
    }, formOptions);
  }

  get f(): { [key: string]: AbstractControl } {
    return this.userForm.controls;
  }


  onLoginFormSubmit(): void {
    this.loginError = {
      status: false,
      message: ''
    };
    console.log('Login Form controls : ', this.loginForm.controls);
    console.log('Login Form Data : ', this.loginForm.value);
    console.log('Login Form status : ', this.loginForm.valid);

    if (this.loginForm.invalid) {
      return;
    }

    this.authService.login(this.loginForm.value.email, this.loginForm.value.password).subscribe((data) => {
      console.log('Login Resp : ', data);
      if (data.isSuccess) {
        this.router.navigate(['/home']);
      } else {
        this.loginError = {
          status: true,
          message: 'Email / Password Incorrect'
        };
      }
    });
  }

  toggleForm(): void {
    this.loginOrRegister = !this.loginOrRegister;
  }

  addUser(input: any): void {
    this.commonService.createOrUpdateUser(input).subscribe((data) => {
      console.log(data);
    });
  }

  onSubmit(): void {
    console.log(this.userForm);
    this.addUser(this.userForm.value);
  }
}
