import { Injectable } from '@angular/core';
import { PageRequest } from '../../../core/models/page/page-request';
import { Observable } from 'rxjs';
import { MaterialListItemDto } from '../../models/responses/materials/material-list-item-dto';

@Injectable({
  providedIn: 'root'
})
export abstract class MaterialListHomeBaseService {

 abstract getList(pageRequest:PageRequest):Observable<MaterialListItemDto>


  abstract getMaterialListByModelId(pageRequest:PageRequest,modelId:string)
  :Observable<MaterialListItemDto>

  // Yeni search metodu
  abstract search(pageRequest: PageRequest, searchText: string): Observable<MaterialListItemDto>;
}
