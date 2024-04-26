import { Injectable } from '@angular/core';
import { MaterialCopyBaseService } from '../abstracts/material-copy-base.service';
import { Observable } from 'rxjs';
import { GetByIdMaterialCopyResponse } from '../../models/responses/material-copies/get-by-id-material-copy-response';
import { GetListMaterialCopyResponse } from '../../models/responses/material-copies/get-list-material-copy-response';

@Injectable({
  providedIn: 'root'
})
export class MaterialCopyService extends MaterialCopyBaseService {
  override getList(): Observable<GetListMaterialCopyResponse[]> {
    throw new Error('Method not implemented.');
  }
  override getById(): Observable<GetByIdMaterialCopyResponse> {
    throw new Error('Method not implemented.');
  }

}
