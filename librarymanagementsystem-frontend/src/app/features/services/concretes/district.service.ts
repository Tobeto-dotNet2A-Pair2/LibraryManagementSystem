import { Injectable } from '@angular/core';
import { DistrictBaseService } from '../abstracts/district-base.service';
import { Observable } from 'rxjs';
import { GetByIdDistrictResponse } from '../../models/responses/districts/get-by-id-district-response';
import { PageResponse } from '../../../core/models/page/page-response';
import { GetListDistrictResponse } from '../../models/responses/districts/get-list-district-response';

@Injectable({
  providedIn: 'root'
})
export class DistrictService extends DistrictBaseService{
  override getByIdDistrict(id: string): Observable<GetByIdDistrictResponse> {
    return this.httpClient.get<GetByIdDistrictResponse>(`${this.apiUrl}/${id}`);
  }
  getDistrictsByCityId(
    cityId: string
  ): Observable<PageResponse<GetListDistrictResponse>> {
    let request = {
      sort: [],
      filter: {
        field: 'cityId',
        operator: 'eq',
        value: cityId,
        logic: 'and',
        filters: [],
      },
    };
    return this.httpClient.post<PageResponse<GetListDistrictResponse>>(
      `${this.apiUrl}/Dynamic?PageIndex=0&PageSize=10000`,
      request
    );
}
}