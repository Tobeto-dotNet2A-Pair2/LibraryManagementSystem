import { Injectable } from '@angular/core';
import { PageRequest } from '../../../core/models/page/page-request';
import { Observable } from 'rxjs';
import { MaterialListDto } from '../../models/responses/materials/material-list-item-dto';
import { DeletedMaterialResponse } from '../../models/responses/materials/deleted-material-response';

@Injectable({
  providedIn: 'root'
})
export abstract class MaterialListBaseService {

  abstract getList(pageRequest:PageRequest):Observable<MaterialListDto>
  abstract getMaterialListByModelId(pageRequest:PageRequest,modelId:string)
  :Observable<MaterialListDto>

  abstract deleteMaterial(materialId: string): Observable<DeletedMaterialResponse>;
}

