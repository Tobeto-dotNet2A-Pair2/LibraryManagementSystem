import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LibraryService } from '../../../../services/concretes/library.service';
import { CreateLibraryRequest } from '../../../../models/requests/libraries/create-library-request';
import { ToastrService } from 'ngx-toastr';
import { GetListLibraryResponse } from '../../../../models/responses/libraries/get-list-library-response';
import { UpdateLibraryRequest } from '../../../../models/requests/libraries/update-library-request';
import { DeleteLibraryRequest } from '../../../../models/requests/libraries/delete-library-request';

@Component({
  selector: 'app-add-library',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-library.component.html',
  styleUrl: './add-library.component.scss'
})
export class AddLibraryComponent implements OnInit {

  libraryForm!: FormGroup;
  libraries: any[] = [];
  
  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService, 
    private libraryService: LibraryService) {}

   ngOnInit(): void {
    this.createLibraryForm();
    // this.getLibraryList();
  }

  private createLibraryForm(): void {
    this.libraryForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(50)])
    });


  }
  onSubmit(): void {
    if (this.libraryForm.invalid) {  return;  }

    //const libraryData: CreateLibraryRequest = {name: this.libraryForm.value.name };

    let libraryData: CreateLibraryRequest = Object.assign({}, this.libraryForm.value);

    this.libraryService.addLibrary(libraryData).subscribe(
     
      () => {
        this.toastr.success("Library added successfully.", "Başarılı");
        console.log("toasttan once");
        this.libraryForm.reset();
      },
      (error) => {
        this.toastr.error('An error occurred while adding the library.');
        console.error(error);
      }
    );
  }
/* Testi Daha yapılmadı
  deleteLibrary(libraryId: string): void {
    this.libraryService.deleteLibrary({ id: libraryId }).subscribe(
      () => {
        this.toastr.success("Library deleted successfully.", "Success");
        this.getLibraryList();
      },
      (error) => {
        this.toastr.error('An error occurred while deleting the library.', "Error");
        console.error(error);
      }
    );
  }

  viewLibraryDetails(libraryId: string): void {
    // Implement logic to view library details
  }

  updateLibrary(libraryId: string): void {
    const updateData: UpdateLibraryRequest = { id: libraryId, name: 'Updated Library Name' }; // Replace with actual update data
    this.libraryService.updateLibrary(updateData).subscribe(
      () => {
        this.toastr.success("Library updated successfully.", "Success");
        this.getLibraryList();
      },
      (error) => {
        this.toastr.error('An error occurred while updating the library.', "Error");
        console.error(error);
      }
    );
  }

  getLibraryList(): void {
    this.libraryService.getAllLibraries().subscribe(
      (response) => {
        this.libraries = response;
      },
      (error) => {
        this.toastr.error('An error occurred while fetching the library list.', "Error");
        console.error(error);
      }
    );
  }
  */
}
