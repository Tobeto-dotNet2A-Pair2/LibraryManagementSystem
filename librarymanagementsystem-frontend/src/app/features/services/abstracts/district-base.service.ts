import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { GetByIdDistrictResponse } from '../../models/responses/districts/get-by-id-district-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class DistrictBaseService {
  protected  apiUrl:string = `${environment.API_URL}/Districts`;
  constructor(protected httpClient: HttpClient) { }

  abstract getByIdDistrict(id: string): Observable<GetByIdDistrictResponse>;
}
