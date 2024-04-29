import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginComponent } from '../../../features/components/auth/login/login.component';
import { RegisterComponent } from '../../../features/components/auth/register/register.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    LoginComponent,
    RegisterComponent,
    HttpClientModule,

  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
})
export class AuthComponent {
  showLoginForm: boolean = false;
  showRegisterForm: boolean = true;

  registerHandler()  {
    this.showLoginForm = true;
    this.showRegisterForm = false;
  }

  loginHandler() {
    this.showLoginForm = false;
    this.showRegisterForm = true;
  }

}
