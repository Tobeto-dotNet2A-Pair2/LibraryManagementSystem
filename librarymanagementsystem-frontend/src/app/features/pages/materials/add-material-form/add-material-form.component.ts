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
import { CreateAuthorRequest } from '../../../models/requests/authors/create-author-request';
import { CreatePublisherRequest } from '../../../models/requests/publishers/create-publisher-request';
import { CreateTranslatorRequest } from '../../../models/requests/translators/create-translator-request';
import { CreateLanguageRequest } from '../../../models/requests/languages/create-language-request';
import { CreateAuthorMaterialRequest } from '../../../models/requests/authorMaterials/create-authorMaterial-request';
import { CreateLanguageMaterialRequest } from '../../../models/requests/languageMaterials/create-languageMaterial-request';
import { CreateTranslatorMaterialRequest } from '../../../models/requests/translatorMaterials/create-translatorMaterial-request';
import { CreatePublisherMaterialRequest } from '../../../models/requests/publisherMaterials/create-publisherMaterial-request';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss',
})
export class AddMaterialFormComponent implements OnInit {
  //Variables Declerations

  //Lists
  materialList: any[] = [];
  branchList: any[] = [];
  locationList: any[] = [];
  authorList: any[] = [];
  publisherList: any[] = [];
  translatorList: any[] = [];
  languageList: any[] = [];
  materialGenreList: any[] = [];

  //FormGroups
  materialForm!: FormGroup;
  materialCopyForm!: FormGroup;
  locationForm!: FormGroup;
  authorForm!: FormGroup;
  publisherForm!: FormGroup;
  translatorForm!: FormGroup;
  languageForm!: FormGroup;
  authorMaterialForm!: FormGroup;
  languageMaterialForm!: FormGroup;
  publisherMaterialForm!: FormGroup;
  translatorMaterialForm!: FormGroup;

  //Constructor
  constructor(
    private managementService: MaterialManagementService,
    private toastr: ToastrService
  ) {}

  //Functions

  ngOnInit(): void {
    flatpickr('#dateReceipt', {});
    //createForms
    this.createMaterialForm();
    this.createMaterialCopyForm();
    this.createLocationForm();
    this.createAuthorForm();
    this.createPublisherForm();
    this.createTranslatorForm();
    this.createLanguageForm();
    this.createAuthorMaterialForm();
    this.createLanguageMaterialForm();
    this.createPublisherMaterialForm();
    this.createTranslatorMaterialForm();
    //Fill lists
    this.getMaterialList();
    this.getBranchList();
    this.getLocationList();
    this.getAuthorList();
    this.getPublisherList();
    this.getTranslatorList();
    this.getLanguageList();
  }
  //CreateForms
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

  private createAuthorForm(): void {
    this.authorForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      country: new FormControl('', [Validators.required]),
    });
  }

  private createPublisherForm(): void {
    this.publisherForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      publicationPlace: new FormControl('', [Validators.required]),
    });
  }

  private createTranslatorForm(): void {
    this.translatorForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
    });
  }

  private createLanguageForm(): void {
    this.languageForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
  }

  private createAuthorMaterialForm(): void {
    this.authorMaterialForm = new FormGroup({
      authorId: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
    });
  }

  private createLanguageMaterialForm(): void {
    this.languageMaterialForm = new FormGroup({
      languageId: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
    });
  }

  private createPublisherMaterialForm(): void {
    this.publisherMaterialForm = new FormGroup({
      publisherId: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
    });
  }

  private createTranslatorMaterialForm(): void {
    this.translatorMaterialForm = new FormGroup({
      translatorId: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
    });
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
        this.getMaterialList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the material.');
        console.error(error);
      }
    );
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
        this.getLocationList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the location.');
        console.error(error);
      }
    );
  }
  //----------------------------------------------------
  onSubmitAuthorForm(): void {
    if (this.authorForm.invalid) {
      return;
    }

    let authorData: CreateAuthorRequest = Object.assign(
      {},
      this.authorForm.value
    );

    this.managementService.addAuthor(authorData).subscribe(
      () => {
        this.toastr.success('Author added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.authorForm.reset();
        this.getAuthorList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the Author.');
        console.error(error);
      }
    );
  }
  //----------------------------------------------------
  onSubmitPublisherForm(): void {
    if (this.publisherForm.invalid) {
      return;
    }

    let publisherData: CreatePublisherRequest = Object.assign(
      {},
      this.publisherForm.value
    );

    this.managementService.addPublisher(publisherData).subscribe(
      () => {
        this.toastr.success('Publisher added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.publisherForm.reset();
        this.getPublisherList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the Publisher.');
        console.error(error);
      }
    );
  }
  //----------------------------------------------------
  onSubmitTranslatorForm(): void {
    if (this.translatorForm.invalid) {
      return;
    }

    let translatorData: CreateTranslatorRequest = Object.assign(
      {},
      this.translatorForm.value
    );

    this.managementService.addTranslator(translatorData).subscribe(
      () => {
        this.toastr.success('Translator added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.translatorForm.reset();
        this.getTranslatorList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the Translator.');
        console.error(error);
      }
    );
  }
  //----------------------------------------------------
  onSubmitLanguageForm(): void {
    if (this.languageForm.invalid) {
      return;
    }

    let languageData: CreateLanguageRequest = Object.assign(
      {},
      this.languageForm.value
    );

    this.managementService.addLanguage(languageData).subscribe(
      () => {
        this.toastr.success('Language added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.languageForm.reset();
        this.getLanguageList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the Language.');
        console.error(error);
      }
    );
  }

  //----------------------------------------------------
    //----------------------------------------------------
    onSubmitAuthorMaterialForm(): void {
      if (this.authorMaterialForm.invalid) {
        return;
      }
  
      let authorMaterialData: CreateAuthorMaterialRequest = Object.assign(
        {},
        this.authorMaterialForm.value
      );
  
      this.managementService.addAuthorMaterial(authorMaterialData).subscribe(
        () => {
          this.toastr.success('AuthorMaterial matched successfully.', 'Başarılı');
          console.log('toasttan once');
          this.authorMaterialForm.reset();
        },
        (error) => {
          this.toastr.error('An error occurred while matching the AuthorMaterial.');
          console.error(error);
        }
      );
    }
        //----------------------------------------------------
        onSubmitLanguageMaterialForm(): void {
          if (this.languageMaterialForm.invalid) {
            return;
          }
      
          let languageMaterialData: CreateLanguageMaterialRequest = Object.assign(
            {},
            this.languageMaterialForm.value
          );
      
          this.managementService.addLanguageMaterial(languageMaterialData).subscribe(
            () => {
              this.toastr.success('LanguageMaterial matched successfully.', 'Başarılı');
              console.log('toasttan once');
              this.languageMaterialForm.reset();
            },
            (error) => {
              this.toastr.error('An error occurred while matching the LanguageMaterial.');
              console.error(error);
            }
          );
        }
            //----------------------------------------------------
    onSubmitPublisherMaterialForm(): void {
      if (this.publisherMaterialForm.invalid) {
        return;
      }
  
      let publisherMaterialData: CreatePublisherMaterialRequest = Object.assign(
        {},
        this.publisherMaterialForm.value
      );
  
      this.managementService.addPublisherMaterial(publisherMaterialData).subscribe(
        () => {
          this.toastr.success('PublisherMaterial matched successfully.', 'Başarılı');
          console.log('toasttan once');
          this.publisherMaterialForm.reset();
        },
        (error) => {
          this.toastr.error('An error occurred while matching the PublisherMaterial.');
          console.error(error);
        }
      );
    }
        //----------------------------------------------------
        onSubmitTranslatorMaterialForm(): void {
          if (this.translatorMaterialForm.invalid) {
            return;
          }
      
          let translatorMaterialData: CreateTranslatorMaterialRequest = Object.assign(
            {},
            this.translatorMaterialForm.value
          );
      
          this.managementService.addTranslatorMaterial(translatorMaterialData).subscribe(
            () => {
              this.toastr.success('TranslatorMaterial matched successfully.', 'Başarılı');
              console.log('toasttan once');
              this.translatorMaterialForm.reset();
            },
            (error) => {
              this.toastr.error('An error occurred while matching the TranslatorMaterial.');
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
        this.toastr.error(
          'An error occurred while fetching the material list.',
          'Error'
        );
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
        this.toastr.error(
          'An error occurred while fetching the Branch list.',
          'Error'
        );
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
        this.toastr.error(
          'An error occurred while fetching the Location list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  getAuthorList(): void {
    this.managementService.getAllAuthors().subscribe(
      (response) => {
        this.authorList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the Author list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  getPublisherList(): void {
    this.managementService.getAllPublishers().subscribe(
      (response) => {
        this.publisherList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the Publisher list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  getTranslatorList(): void {
    this.managementService.getAllTranslators().subscribe(
      (response) => {
        this.translatorList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the Translator list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  getLanguageList(): void {
    this.managementService.getAllLanguages().subscribe(
      (response) => {
        this.languageList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the Language list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  //OPEN/CLOSE MODAL

  openModal(modalId: string): void {
    const modalDiv = document.getElementById(modalId);
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
