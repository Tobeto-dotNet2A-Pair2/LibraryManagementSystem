import { Component } from '@angular/core';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss'
})
export class AddMaterialFormComponent {
  openModal(modalId: string): void {
    const modalDiv = document.getElementById(modalId);
    if (modalDiv) {
      modalDiv.style.display = "block";
    } else {
      console.error("Modal with id '" + modalId + "' not found.");
    }
  }
  closeModal(modalId: string): void {
    const modalDiv = document.getElementById(modalId);
    if (modalDiv) {
      modalDiv.style.display = "none";
    } else {
      console.error("Modal with id '" + modalId + "' not found.");
    }
  }
}
