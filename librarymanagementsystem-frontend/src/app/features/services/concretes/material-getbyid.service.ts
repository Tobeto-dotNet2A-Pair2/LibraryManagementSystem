import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MaterialDetailDto } from '../../models/responses/materials/material-detail-dto';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';
import { MaterialDetailHomeDto } from '../../models/responses/materials/material-detail-home-dto';

@Injectable({
  providedIn: 'root'
})
export class MaterialGetbyidService {
  constructor(private httpClient: HttpClient) { }
  
  getMaterialById(materialId: string): Observable<MaterialDetailDto> {
    return this.httpClient.get<MaterialDetailDto>(`${environment.API_URL}/Materials/GetDetailByIdForAdmin?Id=${materialId}`);

  }

  getMaterialCopyById(materialCopyId: string): Observable<MaterialDetailHomeDto> {
    return this.httpClient.get<MaterialDetailHomeDto>(`${environment.API_URL}/MaterialCopies/GetById/${materialCopyId}`);

  }
  
}
