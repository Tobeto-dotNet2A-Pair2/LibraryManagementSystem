import { Injectable } from '@angular/core';
import { CityBaseService } from '../abstracts/city-base.service';
import { Observable } from 'rxjs';
import { GetByIdCityResponse } from '../../models/responses/cities/get-by-id-city-response';
import { PageResponse } from '../../../core/models/page/page-response';
import { GetListCityResponse } from '../../models/responses/cities/get-list-city-response';

@Injectable({
  providedIn: 'root'
})
export class CityService extends CityBaseService{

  override getByIdCity(id: string): Observable<GetByIdCityResponse> {
    return this.httpClient.get<GetByIdCityResponse>(`${this.apiUrl}/${id}`);
  }

  getAllCities(): Observable<PageResponse<GetListCityResponse>> {
    return this.httpClient.get<PageResponse<GetListCityResponse>>(
      `${this.apiUrl}?PageIndex=0&PageSize=100000`
    );
  }
}
