import { Injectable } from '@angular/core';
import { MaterialBaseService } from '../abstracts/material-base.service';
import { Observable } from 'rxjs';
import { CreateMaterialRequest } from '../../models/requests/materials/create-material-request';
import { CreatedMaterialResponse } from '../../models/responses/materials/created-material-response';
import { GetByIdMaterialResponse } from '../../models/responses/materials/get-by-id-material-response';
import { GetListMaterialResponse } from '../../models/responses/materials/get-list-material-response';

@Injectable({
  providedIn: 'root'
})
export class MaterialService extends MaterialBaseService {
  override getList(): Observable<GetListMaterialResponse[]> {
    throw new Error('Method not implemented.');
  }
  override getById(): Observable<GetByIdMaterialResponse> {
    throw new Error('Method not implemented.');
  }
  override addMaterial(createdMaterialRequest: CreateMaterialRequest): Observable<CreatedMaterialResponse> {
    throw new Error('Method not implemented.');
  }
  
 }
