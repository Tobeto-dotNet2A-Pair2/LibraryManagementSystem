import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetByIdNeighborhoodResponse } from '../../models/responses/neighborhoods/get-by-id-neighborhood-response';

@Injectable({
  providedIn: 'root'
})
export abstract class NeigborhoodBaseService {
  protected  apiUrl:string = `${environment.API_URL}/Neighborhoods`;
  constructor(protected httpClient: HttpClient) { }

  abstract getByIdNeigborhood(id:string): Observable<GetByIdNeighborhoodResponse>;
}
