import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-header-item-usermenu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header-item-usermenu.component.html',
  styleUrl: './header-item-usermenu.component.scss'
})
export class HeaderItemUsermenuComponent {
  @Output() logout = new EventEmitter<void>();


  callLogoutHandler() {
    this.logout.emit();
  }

  
}
