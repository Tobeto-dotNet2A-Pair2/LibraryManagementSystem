import { Injectable } from '@angular/core';
import { PageRequest } from '../../../core/models/page/page-request';
import { Observable } from 'rxjs';
import { MaterialListItemDto } from '../../models/responses/materials/material-list-item-dto';
import { DeletedMaterialResponse } from '../../models/responses/materials/deleted-material-response';

@Injectable({
  providedIn: 'root'
})
export abstract class MaterialListBaseService {

  abstract getList(pageRequest:PageRequest):Observable<MaterialListItemDto>
  abstract getMaterialListByModelId(pageRequest:PageRequest,modelId:string)
  :Observable<MaterialListItemDto>

  abstract deleteMaterial(materialId: string): Observable<DeletedMaterialResponse>;
}

