import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {
  FormBuilder,
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
import { UpdateMaterialRequest } from '../../../models/requests/materials/update-material-request';
import { UpdateAuthorRequest } from '../../../models/requests/authors/update-author-request';
import { UpdateLocationRequest } from '../../../models/requests/locations/update-location-request';
import { CreateGenreRequest } from '../../../models/requests/genres/create-genre-request';
import { CreateMaterialGenreRequest } from '../../../models/requests/materialGenres/create-materialGenre-request';
import { CreateMaterialPropertyRequest } from '../../../models/requests/material-properties/create-material-property-request';
import { CreateMaterialTypeRequest } from '../../../models/requests/material-types/create-material-type-request';
import { CreateMaterialPropertyValueRequest } from '../../../models/requests/material-property-values/create-material-property-value-request';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss',
})
export class AddMaterialFormComponent implements OnInit {
  //Variables Declerations
  isBorrowable: boolean = false;
  borrowDay:string='0';
  isReservable: boolean = false;
  isReserved: boolean = false;
  materialFormat: number = 0;

  selectedFile: File | null = null;
  selectedMaterialId: any;

  //Lists
  materialList: any[] = [];
  branchList: any[] = [];
  locationList: any[] = [];
  authorList: any[] = [];
  publisherList: any[] = [];
  translatorList: any[] = [];
  languageList: any[] = [];
  genreList: any[] = [];
materialPropertyList: any[] = [];
materialTypeList: any[] = [];
  //FormGroups
  materialForm!: FormGroup;
  updateMaterialForm!: FormGroup;

  materialCopyForm!: FormGroup;
  materialImageForm!: FormGroup;
  genreForm!:FormGroup;
  locationForm!: FormGroup;
updateLocationForm!: FormGroup;

  authorForm!: FormGroup;
updateAuthorForm!: FormGroup;

  publisherForm!: FormGroup;
  translatorForm!: FormGroup;
  languageForm!: FormGroup;
  authorMaterialForm!: FormGroup;
  languageMaterialForm!: FormGroup;
  publisherMaterialForm!: FormGroup;
  translatorMaterialForm!: FormGroup;
  materialGenreForm!: FormGroup;
  materialPropertyForm!: FormGroup;
  materialPropertyValueForm!: FormGroup;
  materialTypeForm!: FormGroup;
  //Constructor
  constructor(
    private managementService: MaterialManagementService,
    private toastr: ToastrService,
  ) {}

  //Functions

  ngOnInit(): void {
    flatpickr('#dateReceipt', {});
    //createForms
    this.createMaterialForm();
    this.createMaterialCopyForm();
    this.createMaterialImageForm();
    this.createGenreForm();
    this.createLocationForm();
    this.createAuthorForm();
    this.createPublisherForm();
    this.createTranslatorForm();
    this.createLanguageForm();
    this.createMaterialPropertyForm();
    this.createMaterialPropertyValueForm();
    this.createMaterialTypeForm();
    //aratabloform
    this.createAuthorMaterialForm();
    this.createLanguageMaterialForm();
    this.createPublisherMaterialForm();
    this.createTranslatorMaterialForm();
    this.createMaterialGenreForm();
//updateforms
    this.createUpdateMaterialForm();
    this.createUpdateAuthorForm();
    this.createUpdateLocationForm();
    //Fill lists
    this.getMaterialList();
    this.getBranchList();
    this.getLocationList();
    this.getAuthorList();
    this.getPublisherList();
    this.getTranslatorList();
    this.getLanguageList();
    this.getGenreList();
    this.getMaterialPropertyList();
    this.getMaterialTypeList();
  }
  //CreateForms
  private createMaterialForm(): void {
    this.materialForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      isBorrowable: new FormControl([false]),
      borrowDay: new FormControl('0'),
      punishmentAmount: new FormControl('0'),
    });
  
  }
  

  private createMaterialCopyForm(): void {
    this.materialCopyForm = new FormGroup({
      dateReceipt: new FormControl('', [Validators.required]),
      status: new FormControl('', [Validators.required]),
      isReserved: new FormControl([false]),
      isReservable: new FormControl([false]),
      materialId: new FormControl('', [Validators.required]),
      branchId: new FormControl('', [Validators.required]),
      locationId: new FormControl('', [Validators.required]),
    });
  }

  private createMaterialImageForm(): void {
    this.materialImageForm = new FormGroup({
      image: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
    });
  }

  private createGenreForm(): void {
    this.genreForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
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

  private createMaterialGenreForm(): void {
    this.materialGenreForm = new FormGroup({
      genreId: new FormControl('', [Validators.required]),
      materialId: new FormControl('', [Validators.required]),
    });
  }

  private createMaterialPropertyForm(): void {
    this.materialPropertyForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
  }

  private createMaterialPropertyValueForm(): void {
    this.materialPropertyValueForm = new FormGroup({
      materialId: new FormControl('', [Validators.required]),
      materialTypeId: new FormControl('', [Validators.required]),
      materialPropertyId: new FormControl('', [Validators.required]),
      content: new FormControl('', [Validators.required]),
    });
  }

  private createMaterialTypeForm(): void {
    this.materialTypeForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      materialFormat: new FormControl(0),
    });
  }

  private createUpdateMaterialForm(): void {
    this.updateMaterialForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      isBorrowable: new FormControl([false]),
      borrowDay: new FormControl('0'),
      punishmentAmount: new FormControl('0'),
    });
  }

  private createUpdateAuthorForm(): void {
    this.updateAuthorForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      country: new FormControl('', [Validators.required]),
    });
  }

  private createUpdateLocationForm(): void {
    this.updateLocationForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      floor: new FormControl('', [Validators.required]),
      corridor: new FormControl('', [Validators.required]),
      shelf: new FormControl('', [Validators.required]),
      shelfFloor: new FormControl('', [Validators.required]),
      shelfLineNumber: new FormControl('', [Validators.required]),
      fullLocationMap: new FormControl('', [Validators.required]),
    });
  }

  //OnSubmits

  onSubmitMaterialForm(): void {
    if (this.materialForm.invalid) {
      return;
    }

    const materialData: CreateMaterialRequest = {
      name: this.materialForm.value.name,
      description: this.materialForm.value.description,
      isBorrowable: this.isBorrowable,
      borrowDay: this.materialForm.value.borrowDay,
      punishmentAmount: this.materialForm.value.punishmentAmount
     };

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
  onSubmitMaterialImageForm(): void {
    debugger
if(this.selectedFile){
    // const materialImageData: CreateMaterialImageRequest = {
    //   image: this.selectedFile,
    //   materialId: this.materialForm.value.materialId,
    //  };
    // console.log(materialImageData);
    // let materialImageData: CreateMaterialImageRequest = Object.assign(
    //   {},
    //   this.materialImageForm.value
    // );

    const formData = new FormData();
    formData.append('Image', this.selectedFile);
    formData.append('MaterialId', this.selectedMaterialId);

    this.managementService.addMaterialImage(formData).subscribe(
      () => {
        this.toastr.success('Material Image added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.materialImageForm.reset();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the material Image.');
        console.error(error);
      }
    );}
  }

  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0] as File;
  }
  onMaterialSelected(event: any) {
    this.selectedMaterialId = event.target.value;
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
onSubmitMaterialPropertyForm(): void {
  if (this.materialPropertyForm.invalid) {
    return;
  }

  let materialPropertyData: CreateMaterialPropertyRequest = Object.assign(
    {},
    this.materialPropertyForm.value
  );

  this.managementService.addMaterialProperty(materialPropertyData).subscribe(
    () => {
      this.toastr.success('MaterialProperty added successfully.', 'Başarılı');
      console.log('toasttan once');
      this.materialPropertyForm.reset();
      this.getMaterialPropertyList();
    },
    (error) => {
      this.toastr.error('An error occurred while adding the MaterialProperty.');
      console.error(error);
    }
  );
}
//----------------------------------------------------
onSubmitMaterialTypeForm(): void {
  if (this.materialTypeForm.invalid) {
    return;
  }

  // const materialTypeData: CreateMaterialTypeRequest = {
  //   name: this.materialForm.value.name,
  //   materialFormat: this.materialFormat
  //  };


  let materialTypeData: CreateMaterialTypeRequest = Object.assign(
    {},
    this.materialTypeForm.value
  );

  this.managementService.addMaterialType(materialTypeData).subscribe(
    () => {
      this.toastr.success('MaterialType added successfully.', 'Başarılı');
      console.log('toasttan once');
      this.materialTypeForm.reset();
      this.getMaterialTypeList();
    },
    (error) => {
      this.toastr.error('An error occurred while adding the MaterialType.');
      console.error(error);
    }
  );
}
//----------------------------------------------------
onSubmitMaterialPropertyValueForm(): void {
  if (this.materialPropertyValueForm.invalid) {
    return;
  }

  let materialPropertyValueData: CreateMaterialPropertyValueRequest = Object.assign(
    {},
    this.materialPropertyValueForm.value
  );
console.log(materialPropertyValueData);
  this.managementService.addMaterialPropertyValue(materialPropertyValueData).subscribe(
    () => {
      this.toastr.success('MaterialPropertyValue added successfully.', 'Başarılı');
      console.log('toasttan once');
      this.materialPropertyValueForm.reset();
    },
    (error) => {
      this.toastr.error('An error occurred while adding the MaterialPropertyValue.');
      console.error(error);
    }
  );
}
   //----------------------------------------------------
   onSubmitGenreForm(): void {
    if (this.genreForm.invalid) {
      return;
    }

    let genreData: CreateGenreRequest = Object.assign(
      {},
      this.genreForm.value
    );

    this.managementService.addGenre(genreData).subscribe(
      () => {
        this.toastr.success('Genre added successfully.', 'Başarılı');
        console.log('toasttan once');
        this.genreForm.reset();
        this.getGenreList();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the Genre.');
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
  console.log(authorMaterialData);
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
        onSubmitMaterialGenreForm(): void {
          if (this.materialGenreForm.invalid) {
            return;
          }
      
          let materialGenreData: CreateMaterialGenreRequest = Object.assign(
            {},
            this.materialGenreForm.value
          );
      console.log(materialGenreData);
          this.managementService.addMaterialGenre(materialGenreData).subscribe(
            () => {
              this.toastr.success('MaterialGenre matched successfully.', 'Başarılı');
              console.log('toasttan once');
              this.materialGenreForm.reset();
            },
            (error) => {
              this.toastr.error('An error occurred while matching the MaterialGenre.');
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
//------------------------------------------------------------------------------------
 //Update
 onSubmitUpdateMaterialForm(): void {
  // let updateMaterialData: UpdateMaterialRequest = Object.assign(
  //   {},
  //   this.updateMaterialForm.value
  // );
  const updateMaterialData: UpdateMaterialRequest = {
    id:this.updateMaterialForm.value.id,
    name: this.updateMaterialForm.value.name,
    description: this.updateMaterialForm.value.description,
    isBorrowable: this.isBorrowable,
    borrowDay: this.updateMaterialForm.value.borrowDay,
    punishmentAmount: this.updateMaterialForm.value.punishmentAmount
   };
  this.managementService.updateMaterial(updateMaterialData).subscribe(
    () => {
      this.toastr.success('Material updated successfully.', 'Success');
      this.getMaterialList();
    },
    (error) => {
      this.toastr.error(
        'An error occurred while updating the Material.',
        'Error'
      );
      console.error(error);
    }
  );
}

onMaterialSelect(event: any) {
  const materialId = event.target.value;
  const selectedMaterial = this.materialList.find(material => material.id === materialId);
  if (selectedMaterial) {
    this.updateMaterialForm.patchValue(selectedMaterial);
  }
}
//----------------------------------------------------------------------------------------
onSubmitUpdateAuthorForm(): void {
  let updateAuthorData: UpdateAuthorRequest = Object.assign(
    {},
    this.updateAuthorForm.value
  );
  this.managementService.updateAuthor(updateAuthorData).subscribe(
    () => {
      this.toastr.success('Author updated successfully.', 'Success');
      this.getAuthorList();
    },
    (error) => {
      this.toastr.error(
        'An error occurred while updating the Author.',
        'Error'
      );
      console.error(error);
    }
  );
}

onAuthorSelect(event: any) {
  const authorId = event.target.value;
  const selectedAuthor = this.authorList.find(author => author.id === authorId);
  if (selectedAuthor) {
    this.updateAuthorForm.patchValue(selectedAuthor);
  }
}

//----------------------------------------------------------------------------------------
onSubmitUpdateLocationForm(): void {
  let updateLocationData: UpdateLocationRequest = Object.assign(
    {},
    this.updateLocationForm.value
  );
  this.managementService.updateLocation(updateLocationData).subscribe(
    () => {
      this.toastr.success('Location updated successfully.', 'Success');
      this.getLocationList();
    },
    (error) => {
      this.toastr.error(
        'An error occurred while updating the Location.',
        'Error'
      );
      console.error(error);
    }
  );
}

onLocationSelect(event: any) {
  const locationId = event.target.value;
  const selectedLocation = this.locationList.find(location => location.id === locationId);
  if (selectedLocation) {
    this.updateLocationForm.patchValue(selectedLocation);
  }
}
//---------------------------------------------------
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

  getGenreList(): void {
    this.managementService.getAllGenres().subscribe(
      (response) => {
        this.genreList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the Genre list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  getMaterialPropertyList(): void {
    this.managementService.getAllMaterialProperties().subscribe(
      (response) => {
        this.materialPropertyList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the MaterialProperty list.',
          'Error'
        );
        console.error(error);
      }
    );
  }

  getMaterialTypeList(): void {
    this.managementService.getAllMaterialTypes().subscribe(
      (response) => {
        this.materialTypeList = response;
      },
      (error) => {
        this.toastr.error(
          'An error occurred while fetching the MaterialType list.',
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
