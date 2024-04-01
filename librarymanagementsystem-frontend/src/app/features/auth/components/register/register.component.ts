import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './register.component.html',
  styleUrl: '../../pages/auth/auth.component.scss',
})
export class RegisterComponent {
  @Input() showRegisterForm: boolean = false;
  @Output() loginClicked = new EventEmitter<void>();

  constructor() {}

  callLoginHandler() {
    this.loginClicked.emit();
  }
}