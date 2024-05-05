import { Injectable } from '@angular/core';
import { Observable, filter } from 'rxjs';
import { GetByIdNeighborhoodResponse } from '../../models/responses/neighborhoods/get-by-id-neighborhood-response';
import { GetListNeighborhoodResponse } from '../../models/responses/neighborhoods/get-list-neighborhood-response';
import { PageResponse } from '../../../core/models/page/page-response';
import { NeighborhoodBaseService } from '../abstracts/neighborhood-base.service';

@Injectable({
  providedIn: 'root'
})
export class NeigborhoodService extends NeighborhoodBaseService {
  override getByIdStreet(id: string): Observable<GetByIdNeighborhoodResponse> {
    return this.httpClient.get<GetByIdNeighborhoodResponse>(`${this.apiUrl}/${id}`); 
  }


  getNeighborhoodsByDistrictId(
    districtId: string):
    Observable<PageResponse<GetListNeighborhoodResponse>> {
    let request = {
      sort:[],
      filter:{
        field:'districtId',
        operator: 'eq',
        value: districtId,
        logic: 'and',
        filters: [],
      },
    };
    return this.httpClient.post<PageResponse<GetListNeighborhoodResponse>>(
      `${this.apiUrl}/Dynamic?PageIndex=0&PageSize=10000`,
      request
    );
  }
}
