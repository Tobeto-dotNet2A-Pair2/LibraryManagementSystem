import { CommonModule } from '@angular/common';
import { CommonModule } from '@angular/common';
import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialManagementService } from '../../../services/concretes/material-management.service';
import { MaterialListItemDto } from '../../../models/responses/materials/material-list-item-dto';
import { GetListMaterialResponse } from '../../../models/responses/materials/get-list-material-response';
import { Observable } from 'rxjs';
import { CreateMaterialRequest } from '../../../models/requests/materials/create-material-request';
import { ApiResponse, CreatedMaterialResponse } from '../../../models/responses/materials/created-material-response';

@Component({
  selector: 'app-add-material-form',
  standalone: true,
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './add-material-form.component.html',
  styleUrl: './add-material-form.component.scss'
})
export class AddMaterialFormComponent implements OnInit{
  //Variables Declerations
materialSelectObj: any = 
  {
    "id": "string",
    "name": "string",
    "description": "string",
    "punishmentAmount": 0,
    "isBorrowable": false,
    "borrowDay": 0
  };
  materialCreateObj: any = 
  {
    "name": "string",
    "description": "string",
    "punishmentAmount": 0,
    "isBorrowable": true,
    "borrowDay": 0
  };
  materialList: any [] = [];
  materialForm!: FormGroup;

constructor(private managementService: MaterialManagementService,){

}

//Functions
ngOnInit(): void {
  this.getAllMaterials();
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


getAllMaterials(){
  this.managementService.getMaterials().subscribe((res:any)=>{
    this.materialList = res.data;
  })
}


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
