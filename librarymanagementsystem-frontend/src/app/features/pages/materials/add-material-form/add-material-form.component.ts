import { Component } from '@angular/core';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss'
})
export class AddMaterialFormComponent {
  isFormEnabled: boolean = true;

  toggleForm(checked: boolean): void {
    this.isFormEnabled = checked;
  }

  submitForm(): void {
    // Form submit işlemleri buraya gelecek
  }
}
