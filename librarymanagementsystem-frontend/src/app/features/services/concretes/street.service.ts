import { Injectable } from '@angular/core';
import { StreetBaseService } from '../abstracts/street-base.service';
import { Observable } from 'rxjs';
import { GetByIdStreetResponse } from '../../models/responses/streets/get-by-id-street-response';
import { PageResponse } from '../../../core/models/page/page-response';
import { GetListStreetResponse } from '../../models/responses/streets/get-list-street-response';

@Injectable({
  providedIn: 'root'
})
export class StreetService extends StreetBaseService {
  override getByIdStreet(id: string): Observable<GetByIdStreetResponse> {
    return this.httpClient.get<GetByIdStreetResponse>(`${this.apiUrl}/${id}`); 
  }

  getStreetsByNeighborhoodId
  (neighborhoodId: string):
   Observable<PageResponse<GetListStreetResponse>> {
    let request = {
      sort: [],
      filter: {
        field: 'neighborhoodId',
        operator: 'eq',
        value: neighborhoodId,
        logic: 'and',
        filters: [],
      },
    };
    
    return this.httpClient.post<PageResponse<GetListStreetResponse>>(
      `${this.apiUrl}/Dynamic?PageIndex=0&PageSize=10000`,
      request
    );
  }
}
