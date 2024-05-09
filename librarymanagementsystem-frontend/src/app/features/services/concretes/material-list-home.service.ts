import { Injectable } from '@angular/core';
import { MaterialListHomeBaseService } from '../abstracts/material-list-home-base.service';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { PageRequest } from '../../../core/models/page/page-request';
import { MaterialListItemDto } from '../../models/responses/materials/material-list-item-dto';
import { environment } from '../../../../environments/environment';
import { MaterialCopyListItemDto } from '../../models/responses/material-copies/materialcopy-list-item-dto';

@Injectable({
  providedIn: 'root'
})
export class MaterialListHomeService extends MaterialListHomeBaseService{

  constructor(private httpClient:HttpClient) {super() }
  private readonly apiUrl:string = `${environment.API_URL}`
 // private readonly apiUrl:string = `${environment.API_URL}/MaterialCopies`

  override getList(pageRequest: PageRequest): Observable<MaterialCopyListItemDto> {
    const newRequest: {[key: string]: string | number} = {
      pageIndex: pageRequest.pageIndex,
      pageSize: pageRequest.pageSize,
    };
    return this.httpClient.get<MaterialCopyListItemDto>(`${this.apiUrl}/Materials/GetListForAdmin`,{
      params:newRequest
    }).pipe(
      map((response)=>{
        const newResponse:MaterialCopyListItemDto={

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
  

   override search(pageRequest: PageRequest, searchText:string): Observable<MaterialCopyListItemDto> {
    const newRequest :{[key:string]:string | number}={
      pageIndex:pageRequest.pageIndex,
      pageSize:pageRequest.pageSize,
      //searchText:"" for search 
      //searchText:string
      searchText: searchText,
};


return this.httpClient.get<MaterialCopyListItemDto>(`${this.apiUrl}/MaterialCopies/GetList`,{
  params:newRequest
}).pipe(
  // map((response)=>{
  //   const newResponse:MaterialListItemDto={
  //     index:pageRequest.pageIndex,
  //     size:pageRequest.pageSize,
  //     count:response.count,
  //     hasNext:response.hasNext,
  //     hasPrevious:response.hasPrevious,
  //     items:response.items,
  //     pages:response.pages
  //   };
  //   return newResponse;
   map((response: any) => {
          return this.mapMaterialListResponse(response);
  })
)
}
private mapMaterialListResponse(response: any): MaterialCopyListItemDto {
    return {
      index: response.index,
      size: response.size,
      count: response.count,
      hasNext: response.hasNext,
      hasPrevious: response.hasPrevious,
      items: response.items,
      pages: response.pages
    };
  }

override getMaterialListByModelId(pageRequest: PageRequest, modelId: string): Observable<MaterialCopyListItemDto> {
const newRequest :{[key:string]:string | number}={
  pageIndex:pageRequest.pageIndex,
  pageSize:pageRequest.pageSize,
  modelId:modelId
};

return this.httpClient.get<MaterialCopyListItemDto>(`${this.apiUrl}/MaterialCopies/GetList/getmaterialbymodel`,{
  params:newRequest
}).pipe(
  map((response)=>{
    const newResponse:MaterialCopyListItemDto={
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

