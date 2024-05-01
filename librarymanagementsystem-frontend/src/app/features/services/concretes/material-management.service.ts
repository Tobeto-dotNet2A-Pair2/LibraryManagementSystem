import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MaterialManagementBaseService } from '../abstracts/material-management-base.service';
import { Observable, catchError, throwError } from 'rxjs';
import { GetListMaterialResponse } from '../../models/responses/materials/get-list-material-response';
import { GetByIdMaterialResponse } from '../../models/responses/materials/get-by-id-material-response';
import { MaterialListItemDto } from '../../models/responses/materials/material-list-item-dto';
import { ApiResponse, CreatedMaterialResponse } from '../../models/responses/materials/created-material-response';
import { CreateMaterialRequest } from '../../models/requests/materials/create-material-request';
import { environment } from '../../../../environments/environment';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class MaterialManagementService  {
  private readonly materialApiUrl = `${environment.API_URL}/Materials`;
  

  constructor(
    private httpClient:HttpClient,
    private toastr: ToastrService
  ) { }

    

   addMaterial(createMaterialRequest: CreateMaterialRequest)
      :Observable<CreatedMaterialResponse> {

        return this.httpClient.post<CreatedMaterialResponse>(`${this.materialApiUrl}`, createMaterialRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }
      getAllMaterials(): Observable<GetListMaterialResponse[]> {
        return this.httpClient.get<GetListMaterialResponse[]>(`${this.materialApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Materials.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }



 
  // getMaterials(){
  //   return this.http.get('${environment.API_URL}/materials');
  // }
  // createMaterial(obj : CreateMaterialRequest): Observable<ApiResponse<CreatedMaterialResponse>>{
  //   return this.http.post<ApiResponse<CreatedMaterialResponse>>('${environment.API_URL}/materials', obj);
  // }
}
