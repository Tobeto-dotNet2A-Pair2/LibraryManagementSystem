import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MaterialManagementService } from '../../../services/concretes/material-management.service';
import { CreateMaterialRequest } from '../../../models/requests/materials/create-material-request';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss',
})
export class AddMaterialFormComponent implements OnInit {
  //Variables Declerations
  materialSelectObj: any = {
    id: 'string',
    name: 'string',
    description: 'string',
    punishmentAmount: 0,
    isBorrowable: false,
    borrowDay: 0,
  };
  materialCreateObj: any = {
    name: 'string',
    description: 'string',
    punishmentAmount: 0,
    isBorrowable: true,
    borrowDay: 0,
  };
  materialList: any[] = [];
  materialForm!: FormGroup;

  constructor(
    private managementService: MaterialManagementService,
    private toastr: ToastrService
  ) {}

  //Functions
  ngOnInit(): void {
    //this.getAllMaterials();
    this.createMaterialForm();
  }

  private createMaterialForm(): void {
    this.materialForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      isBorrowable: new FormControl('', [Validators.required]),
      borrowDay: new FormControl('', [Validators.required]),
      punishmentAmount: new FormControl('', [Validators.required]),
    });
  }

  onSubmit(): void {
    if (this.materialForm.invalid) {
      return;
    }

    // const materialData: CreateMaterialRequest = {
    //   name: this.materialForm.value.name,
    //   description: this.materialForm.value.description,
    //   isBorrowable: this.materialForm.value.isBorrowable,
    //   borrowDay: this.materialForm.value.borrowDay,
    //   punishmentAmount: this.materialForm.value.punishmentAmount
    //  };

    let materialData: CreateMaterialRequest = Object.assign(
      {},
      this.materialForm.value
    );

    this.managementService.addMaterial(materialData).subscribe(
      () => {
        this.toastr.success('Material added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.materialForm.reset();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the material.');
        console.error(error);
      }
    );
  }
  // saveMaterial(material: CreatedMaterialResponse): Observable<ApiResponse<CreateMaterialRequest>>{
  //   return this.http.
  //   this.managementService.createMaterial(this.materialCreateObj).subscribe((res:any)=>{
  //     if(res.result){
  //       alert("Materyal Oluşturuldu.");
  //       this.getAllMaterials();
  //     } else {
  //       alert(res.message);
  //     }
  //   })
  // }

  // getAllMaterials(){
  //   this.managementService.getMaterials().subscribe((res:any)=>{
  //     this.materialList = res.data;
  //   })
  // }

  openModal(modalId: string): void {
    const modalDiv = document.getElementById(modalId);
    this.createMaterialForm();
    // switch (modalId) {
    //   case 'materialModal':
    //     this.createMaterialForm();
    //     break;
    //   default:
    //     break;
    // }
    if (modalDiv) {
      modalDiv.style.display = 'block';
    } else {
      console.error("Modal with id '" + modalId + "' not found.");
    }
  }

  closeModal(modalId: string): void {
    const modalDiv = document.getElementById(modalId);
    if (modalDiv) {
      modalDiv.style.display = 'none';
    } else {
      console.error("Modal with id '" + modalId + "' not found.");
    }
  }

  //Custom-Dropdown
  @ViewChild('txtSearchValue') txtSearchValue!: ElementRef;

  options = [
    { value: '1', displayText: 'Option 1', hidden: false },
    { value: '2', displayText: 'Option 2', hidden: false },
    { value: '3', displayText: 'Option 3', hidden: false },
  ];

  selectedOption = this.options[0];
  isOpen = false;

  filterOptions(value: string): void {
    this.options.forEach((option) => {
      option.hidden =
        option.displayText.toLowerCase().indexOf(value.toLowerCase()) === -1;
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
