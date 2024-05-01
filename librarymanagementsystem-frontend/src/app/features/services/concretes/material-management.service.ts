import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MaterialManagementBaseService } from '../abstracts/material-management-base.service';
import { Observable, map } from 'rxjs';
import { GetListMaterialResponse } from '../../models/responses/materials/get-list-material-response';
import { GetByIdMaterialResponse } from '../../models/responses/materials/get-by-id-material-response';
import { MaterialListItemDto } from '../../models/responses/materials/material-list-item-dto';
import { ApiResponse, CreatedMaterialResponse } from '../../models/responses/materials/created-material-response';
import { CreateMaterialRequest } from '../../models/requests/materials/create-material-request';

@Injectable({
  providedIn: 'root'
})
export class MaterialManagementService extends MaterialManagementBaseService {
  private readonly materialApiUrl = '${environment.API_URL}/materials'
  apiGetbyIdURL =''


  constructor(private http: HttpClient) {super() }


  override getMaterialList(): Observable<GetListMaterialResponse[]> {
    return this.http.get<GetListMaterialResponse[]>(this.materialApiUrl);
  }
  override getMaterialById(): Observable<GetByIdMaterialResponse>{
    return this.http.get<GetByIdMaterialResponse>(this.materialApiUrl)
  };
  override getMaterialListAll(): Observable<MaterialListItemDto> {
    const newRequest: {[key: string]: string | number} = {
      page: 0,
      pageSize: 100
    };

      return this.http.get<MaterialListItemDto>(this.materialApiUrl, {
        params: newRequest
      }).pipe(
        map((response)=>{
          const newResponse:MaterialListItemDto={
            index:0,
            size:100,
            count:response.count,
            hasNext:response.hasNext,
            hasPrevious:response.hasPrevious,
            items:response.items,
            pages:response.pages
          };
          return newResponse;
        })
      )
    }
  getMaterials(){
    return this.http.get('${environment.API_URL}/materials');
  }
  createMaterial(obj : CreateMaterialRequest): Observable<ApiResponse<CreatedMaterialResponse>>{
    return this.http.post<ApiResponse<CreatedMaterialResponse>>('${environment.API_URL}/materials', obj);
  }
}
