import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetListMaterialResponse } from '../../models/responses/materials/get-list-material-response';
import { GetByIdMaterialResponse } from '../../models/responses/materials/get-by-id-material-response';
import { CreatedMaterialResponse } from '../../models/responses/materials/created-material-response';
import { CreateMaterialRequest } from '../../models/requests/materials/create-material-request';

@Injectable(
  //{ providedIn: 'root'}
)
export abstract class MaterialBaseService {

  abstract getList(): Observable<GetListMaterialResponse[]>;

  abstract getById(): Observable<GetByIdMaterialResponse>;

  abstract addMaterial(createdMaterialRequest:CreateMaterialRequest):Observable<CreatedMaterialResponse>;

  //abstract GetListAll():  Observable<MaterialListItemDto>;
 


}
