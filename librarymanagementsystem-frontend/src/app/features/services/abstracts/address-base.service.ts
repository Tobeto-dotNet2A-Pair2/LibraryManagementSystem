import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';
import { environment } from '../../../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export abstract class AddressBaseService {
  protected  apiUrl:string = `${environment.API_URL}/Addresses`;
  constructor(protected httpClient: HttpClient) { }

  abstract getByIdCity(id: string): Observable<GetByIdAddressResponse>;

}