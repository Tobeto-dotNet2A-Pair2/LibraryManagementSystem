import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from '../../components/login/login.component';
import { RegisterComponent } from '../../components/register/register.component';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    LoginComponent,
    RegisterComponent,
  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss',
})
export class AuthComponent {
  showLoginForm: boolean = false;
  showSigninForm: boolean = true;

  registerHandler()  {
    this.showLoginForm = true;
    this.showSigninForm = false;
  }

  loginHandler() {
    this.showLoginForm = false;
    this.showSigninForm = true;
  }
}
