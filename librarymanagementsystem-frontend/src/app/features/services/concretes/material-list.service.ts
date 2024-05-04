import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Observable, map } from 'rxjs';
import { MaterialListBaseService } from '../abstracts/material-list-base.service';
import { PageRequest } from '../../../core/models/page/page-request';
import { MaterialListDto } from '../../models/responses/materials/material-list-item-dto';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class MaterialListService extends MaterialListBaseService{
 private readonly apiUrl:string = `${environment.API_URL}/Materials/GetList`
  constructor(private httpClient:HttpClient) {super() }

  override getList(pageRequest: PageRequest): Observable<MaterialListDto> {
    const newRequest :{[key:string]:string | number}={
      pageIndex:pageRequest.pageIndex,
      pageSize:pageRequest.pageSize
    };
    return this.httpClient.get<MaterialListDto>(this.apiUrl,{
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
 
    return this.httpClient.get<MaterialListDto>(`${this.apiUrl}/getmaterialbymodel`,{
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

  

}

