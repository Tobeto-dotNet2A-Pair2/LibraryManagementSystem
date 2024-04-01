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
  @Input() showLoginForm: boolean = false;
  @Output() registerClicked = new EventEmitter<void>();

  constructor() {}

  callRegisterHandler() {
    this.registerClicked.emit();
  }
}