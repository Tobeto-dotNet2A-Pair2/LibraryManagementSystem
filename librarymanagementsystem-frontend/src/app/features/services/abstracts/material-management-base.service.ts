import { Injectable } from '@angular/core';
import { GetListMaterialResponse } from '../../models/responses/materials/get-list-material-response';
import { GetByIdMaterialResponse } from '../../models/responses/materials/get-by-id-material-response';
import { Observable } from 'rxjs';
import { MaterialListItemDto } from '../../models/responses/materials/material-list-item-dto';
import { CreatedMaterialResponse } from '../../models/responses/materials/created-material-response';

@Injectable()
export abstract class MaterialManagementBaseService {
  abstract getMaterialList(): Observable<GetListMaterialResponse[]>;
  abstract getMaterialById(): Observable<GetByIdMaterialResponse>;
  abstract getMaterialListAll(): Observable<MaterialListItemDto>;
  
  abstract addMaterial(): Observable<CreatedMaterialResponse>;
}
