import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetByIdDistrictResponse } from '../../models/responses/districts/get-by-id-district-response';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export abstract class DistrictBaseService {
  protected  apiUrl:string = `${environment.API_URL}/Districts`;
  constructor(protected httpClient: HttpClient) { }

  abstract getByIdDistrict(id: string): Observable<GetByIdDistrictResponse>;
}
