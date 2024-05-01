import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-custom-select-dropdown',
  standalone: true,
  imports: [],
  templateUrl: './custom-select-dropdown.component.html',
  styleUrl: './custom-select-dropdown.component.scss'
})
export class CustomSelectDropdownComponent {
  @ViewChild('txtSearchValue') txtSearchValue!: ElementRef;

  options = [
    { value: '1', displayText: 'Option 1', hidden: false },
    { value: '2', displayText: 'Option 2', hidden: false },
    { value: '3', displayText: 'Option 3', hidden: false }
  ];

  selectedOption = this.options[0];
  isOpen = false;

  filterOptions(value: string): void {
    this.options.forEach(option => {
      option.hidden = option.displayText.toLowerCase().indexOf(value.toLowerCase()) === -1;
    });
  }

  onSelect(option: any): void {
    this.selectedOption = option;
    this.isOpen = false;
  }

  toggleDropdown(): void {
    this.isOpen = !this.isOpen;
    if (this.isOpen) {
      setTimeout(() => this.txtSearchValue.nativeElement.focus(), 0);
    }
  }

  closeDropdown(event: MouseEvent): void {
    if (!(event.target as HTMLElement).closest('.dropdown-select')) {
      this.isOpen = false;
    }
  }

  onKeyDown(event: KeyboardEvent): void {
    if (event.key === 'Escape') {
      this.isOpen = false;
    }
  }
}
