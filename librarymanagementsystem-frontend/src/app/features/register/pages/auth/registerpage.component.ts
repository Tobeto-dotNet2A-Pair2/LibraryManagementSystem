import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-registerpage',
  standalone: true,
  imports: [CommonModule,FormsModule, ReactiveFormsModule ],
  templateUrl: './registerpage.component.html',
  styleUrl: './registerpage.component.scss',
})
export class RegisterpageComponent {
  registerForm!:FormsModule;
  showLoginForm: boolean = false;
  showSigninForm: boolean = true;

  registerHandler(event: Event) {
    event.preventDefault();
    this.showLoginForm = true;
    this.showSigninForm = false;
  }

  loginHandler(event: Event) {
    event.preventDefault();
    this.showLoginForm = false;
    this.showSigninForm = true;
  }
}
