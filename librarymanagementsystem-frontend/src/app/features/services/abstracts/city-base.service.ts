import { Injectable } from '@angular/core';
import { GetByIdCityResponse } from '../../models/responses/cities/get-by-id-city-response';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export abstract class CityBaseService {
  protected  apiUrl:string = `${environment.API_URL}/Cities`;
  constructor(protected httpClient: HttpClient) { }

  abstract getByIdCity(id: string): Observable<GetByIdCityResponse>;
}
