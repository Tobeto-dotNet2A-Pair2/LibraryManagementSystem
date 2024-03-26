import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: '../../pages/auth/auth.component.scss',
})
export class LoginComponent {
  @Input() showLoginForm: boolean=false;
  @Input() registerHandler: Function;
  constructor() {
    this.registerHandler = () => {};
  }
  callRegisterHandler() {
    if (this.registerHandler) {
      this.registerHandler();
    }
  }
}
