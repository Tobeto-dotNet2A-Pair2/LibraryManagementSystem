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
import { GetListBranchResponse } from '../../models/responses/branches/get-list-branch-response';
import { GetListLocationResponse } from '../../models/responses/locations/get-list-location-response';
import { CreateMaterialCopyRequest } from '../../models/requests/material-copies/create-material-copy-request';
import { CreatedMaterialCopyResponse } from '../../models/responses/material-copies/created-material-copy-response';
import { CreateLocationRequest } from '../../models/requests/locations/create-location-request';
import { CreatedLocationResponse } from '../../models/responses/locations/created-location-response';

@Injectable({
  providedIn: 'root'
})
export class MaterialManagementService  {
  private readonly materialApiUrl = `${environment.API_URL}/Materials`;
  private readonly materialCopyApiUrl = `${environment.API_URL}/MaterialCopies`;
  private readonly branchApiUrl = `${environment.API_URL}/Branches`;
  private readonly locationApiUrl = `${environment.API_URL}/Locations`;
  

  constructor(
    private httpClient:HttpClient,
    private toastr: ToastrService
  ) { }

    
//Add
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

      addMaterialCopy(createMaterialCopyRequest: CreateMaterialCopyRequest)
      :Observable<CreatedMaterialCopyResponse> {

        return this.httpClient.post<CreatedMaterialCopyResponse>(`${this.materialCopyApiUrl}`, createMaterialCopyRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addLocation(createLocationRequest: CreateLocationRequest)
      :Observable<CreatedLocationResponse> {

        return this.httpClient.post<CreatedLocationResponse>(`${this.locationApiUrl}`, createLocationRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }
//GetAll

      getAllMaterials(): Observable<GetListMaterialResponse[]> {
        return this.httpClient.get<GetListMaterialResponse[]>(`${this.materialApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Materials.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllBranches(): Observable<GetListBranchResponse[]> {
        return this.httpClient.get<GetListBranchResponse[]>(`${this.branchApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Branches.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllLocations(): Observable<GetListLocationResponse[]> {
        return this.httpClient.get<GetListLocationResponse[]>(`${this.locationApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Locations.", "Error");
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
