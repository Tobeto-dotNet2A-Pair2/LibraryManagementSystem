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
import flatpickr from 'flatpickr';
import { Tagify, TagifyModule } from 'ngx-tagify'; 
import { CreateMaterialCopyRequest } from '../../../models/requests/material-copies/create-material-copy-request';
import { CreateLocationRequest } from '../../../models/requests/locations/create-location-request';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss',
})
export class AddMaterialFormComponent implements OnInit {
  //Variables Declerations
  // materialSelectObj: any = {
  //   id: 'string',
  //   name: 'string',
  //   description: 'string',
  //   punishmentAmount: 0,
  //   isBorrowable: false,
  //   borrowDay: 0,
  // };
  // materialCreateObj: any = {
  //   name: 'string',
  //   description: 'string',
  //   punishmentAmount: 0,
  //   isBorrowable: true,
  //   borrowDay: 0,
  // };
  
 
  //Lists
  materialList: any[] = [];
  branchList: any[] = [];
  locationList: any[] = [];
  materialGenreList: any[] = [];

//FormGroups
  materialForm!: FormGroup;
  materialCopyForm!: FormGroup;
  locationForm!: FormGroup;

  private createMaterialForm(): void {
    this.materialForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      isBorrowable: new FormControl('', [Validators.required]),
      borrowDay: new FormControl('', [Validators.required]),
      punishmentAmount: new FormControl('', [Validators.required]),
    });
  }  
  private createMaterialCopyForm(): void {
    this.materialCopyForm = new FormGroup({
      dateReceipt: new FormControl('', [Validators.required]),
      status: new FormControl('', [Validators.required]),
      isReserved: new FormControl('', [Validators.required]),
      isReservable: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
      branchId: new FormControl('', [Validators.required]),
      locationId: new FormControl('', [Validators.required]),
    });
  }
  private createLocationForm(): void {
    this.locationForm = new FormGroup({
      floor: new FormControl('', [Validators.required]),
      corridor: new FormControl('', [Validators.required]),
      shelf: new FormControl('', [Validators.required]),
      shelfFloor: new FormControl('', [Validators.required]),
      shelfLineNumber: new FormControl('', [Validators.required]),
      fullLocationMap: new FormControl('', [Validators.required]),
    });
  }
//Constructor
  constructor(
    private managementService: MaterialManagementService,
    private toastr: ToastrService,
  ) {}

  //Functions
  ngOnInit(): void {
    flatpickr("#dateReceipt", {});
    //this.getAllMaterials();
    this.createMaterialForm();
    this.createMaterialCopyForm();
    this.createLocationForm();

    this.getMaterialList();
    this.getBranchList();
    this.getLocationList();
    
  }

//OnSubmits

  onSubmitMaterialForm(): void {
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
    this.getMaterialList();
  }
//----------------------------------------------------
  onSubmitMaterialCopyForm(): void {
    if (this.materialCopyForm.invalid) {
      return;
    }

    let materialCopyData: CreateMaterialCopyRequest = Object.assign(
      {},
      this.materialCopyForm.value
    );

    this.managementService.addMaterialCopy(materialCopyData).subscribe(
      () => {
        this.toastr.success('Material Copy added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.materialCopyForm.reset();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the material copy.');
        console.error(error);
      }
    );
  }
  //----------------------------------------------------
  onSubmitLocationForm(): void {
    if (this.locationForm.invalid) {
      return;
    }

    let locationData: CreateLocationRequest = Object.assign(
      {},
      this.locationForm.value
    );

    this.managementService.addLocation(locationData).subscribe(
      () => {
        this.toastr.success('location added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.locationForm.reset();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the location.');
        console.error(error);
      }
    );
  }

//GetLists
  getMaterialList(): void {
    this.managementService.getAllMaterials().subscribe(
      (response) => {
        this.materialList = response;
      },
      (error) => {
        this.toastr.error('An error occurred while fetching the material list.', "Error");
        console.error(error);
      }
    );
  }

  getBranchList(): void {
    this.managementService.getAllBranches().subscribe(
      (response) => {
        this.branchList = response;
      },
      (error) => {
        this.toastr.error('An error occurred while fetching the Branch list.', "Error");
        console.error(error);
      }
    );
  }

  getLocationList(): void {
    this.managementService.getAllLocations().subscribe(
      (response) => {
        this.locationList = response;
      },
      (error) => {
        this.toastr.error('An error occurred while fetching the Location list.', "Error");
        console.error(error);
      }
    );
  }

//OPEN/CLOSE MODAL

  openModal(modalId: string): void {
    const modalDiv = document.getElementById(modalId);
    // this.createMaterialForm();
    // this.createMaterialCopyForm();
    // switch (modalId) {
    //   case 'materialModal':
    //     this.createMaterialForm();
    //     break;
    //   case 'materialCopyModal':
    //     this.createMaterialCopyForm();
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

  //ThemeCodes

  

  //Custom-Dropdown
  // @ViewChild('txtSearchValue') txtSearchValue!: ElementRef;

  // options = [
  //   { value: '1', displayText: 'Option 1', hidden: false },
  //   { value: '2', displayText: 'Option 2', hidden: false },
  //   { value: '3', displayText: 'Option 3', hidden: false },
  // ];

  // selectedOption = this.options[0];
  // isOpen = false;

  // filterOptions(value: string): void {
  //   this.options.forEach((option) => {
  //     option.hidden =
  //       option.displayText.toLowerCase().indexOf(value.toLowerCase()) === -1;
  //   });
  // }

  // onSelect(option: any): void {
  //   this.selectedOption = option;
  //   this.isOpen = false;
  // }

  // toggleDropdown(): void {
  //   this.isOpen = !this.isOpen;
  //   if (this.isOpen) {
  //     setTimeout(() => this.txtSearchValue.nativeElement.focus(), 0);
  //   }
  // }

  // closeDropdown(event: MouseEvent): void {
  //   if (!(event.target as HTMLElement).closest('.dropdown-select')) {
  //     this.isOpen = false;
  //   }
  // }

  // onKeyDown(event: KeyboardEvent): void {
  //   if (event.key === 'Escape') {
  //     this.isOpen = false;
  //   }
  // }
}
