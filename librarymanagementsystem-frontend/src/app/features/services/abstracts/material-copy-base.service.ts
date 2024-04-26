import { Injectable } from '@angular/core';
import { GetListMaterialCopyResponse } from '../../models/responses/material-copies/get-list-material-copy-response';
import { GetByIdMaterialCopyResponse } from '../../models/responses/material-copies/get-by-id-material-copy-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class MaterialCopyBaseService {


  abstract getList(): Observable<GetListMaterialCopyResponse[]>;

  abstract getById(): Observable<GetByIdMaterialCopyResponse>;
}
