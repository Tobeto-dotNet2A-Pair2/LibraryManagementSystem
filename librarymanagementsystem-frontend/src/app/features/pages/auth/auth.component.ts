import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from '../../../features/components/auth/login/login.component';
import { RegisterComponent } from '../../../features/components/auth/register/register.component';

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
