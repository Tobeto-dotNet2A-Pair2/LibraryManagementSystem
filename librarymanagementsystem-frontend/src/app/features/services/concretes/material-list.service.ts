import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable, map } from 'rxjs';
import { MaterialListBaseService } from '../abstracts/material-list-base.service';
import { PageRequest } from '../../../core/models/page/page-request';
import { MaterialListDto } from '../../models/responses/materials/material-list-item-dto';
import { Injectable } from '@angular/core';
import { DeleteMaterialRequest } from '../../models/requests/materials/delete-material-request';
import { DeletedMaterialResponse } from '../../models/responses/materials/deleted-material-response';



@Injectable({
  providedIn: 'root'
})
export class MaterialListService extends MaterialListBaseService{
 private readonly apiUrl:string = `${environment.API_URL}/Materials`
  constructor(private httpClient:HttpClient) {super() }

  override getList(pageRequest: PageRequest): Observable<MaterialListDto> {
    const newRequest :{[key:string]:string | number}={
      pageIndex:pageRequest.pageIndex,
      pageSize:pageRequest.pageSize
    };
    return this.httpClient.get<MaterialListDto>(`${this.apiUrl}/GetList`,{
      params:newRequest
    }).pipe(
      map((response)=>{
        const newResponse:MaterialListDto={
          index:pageRequest.pageIndex,
          size:pageRequest.pageSize,
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
  
  override getMaterialListByModelId(pageRequest: PageRequest, modelId: string): Observable<MaterialListDto> {
    const newRequest :{[key:string]:string | number}={
      pageIndex:pageRequest.pageIndex,
      pageSize:pageRequest.pageSize,
      modelId:modelId
    };
 
    return this.httpClient.get<MaterialListDto>(`${this.apiUrl}/GetList/getmaterialbymodel`,{
      params:newRequest
    }).pipe(
      map((response)=>{
        const newResponse:MaterialListDto={
          index:pageRequest.pageIndex,
          size:pageRequest.pageSize,
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

  
  deleteMaterial(materialId: string): Observable<DeletedMaterialResponse> {
    return this.httpClient.delete<DeletedMaterialResponse>(`${this.apiUrl}/Delete/${materialId}`);
  }
}
