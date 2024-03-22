import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-registerpage',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './registerpage.component.html',
  styleUrl: './registerpage.component.scss',
})
export class RegisterpageComponent {
  showLoginForm: boolean = false;
  showSigninForm: boolean = true;

  registerHandler() {
    this.showLoginForm = true;
    this.showSigninForm = false;
  }

  loginHandler() {
    this.showLoginForm = false;
    this.showSigninForm = true;
  }
}
