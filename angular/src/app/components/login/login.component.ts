import { Component, OnInit } from '@angular/core';
import { CommonService } from '../common.service';
import {
  FormBuilder,
  FormControlName,
  FormGroup,
  Validators,
} from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  userForm!: FormGroup;
  loginOrRegister = true;

  constructor(private commonService: CommonService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.registerForm();
  }

  registerForm() {
    this.userForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.maxLength(10)]],
      roleId: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }
  toggleRegistration(input: any) {
    this.loginOrRegister = input;
  }

  addUser(input: any) {
    this.commonService.createOrUpdate(input).subscribe((data) => {
      console.log(data);
    });
  }
  onSubmit() {
    console.log(this.userForm);
    this.addUser(this.userForm.value);
  }
}
