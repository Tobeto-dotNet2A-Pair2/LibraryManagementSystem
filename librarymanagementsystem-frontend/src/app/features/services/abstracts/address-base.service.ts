import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../../../shared/services/base.service';
import { HttpClient } from '@angular/common/http';
import { CreatedAddressResponse } from '../../models/responses/addresses/created-address-response';
import { UpdatedAddressResponse } from '../../models/responses/addresses/updated-address-response';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';
import { GetListAddressResponse } from '../../models/responses/addresses/get-list-address-response';
import { DeletedAddressResponse } from '../../models/responses/addresses/deleted-address-response';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AddressBaseService {
  private apiUrl = environment.API_URL;
  private addressEndpoint = environment.addressEndpoint;

  constructor(protected override httpClient: HttpClient) {
    super(httpClient);
  }

   getAddressById(id: string): Observable<GetByIdAddressResponse> {
    const url = `${this.apiUrl}${this.addressEndpoint}/${id}`;
    return this.httpClient.get<GetByIdAddressResponse>(url);
  }

 createAddress(data: any): Observable<CreatedAddressResponse> {
    const url = `${this.apiUrl}${this.addressEndpoint}`;
    return this.httpClient.post<CreatedAddressResponse>(url, data);
  }

  updateAddress(id: string, data: any): Observable<UpdatedAddressResponse> {
    const url = `${this.apiUrl}${this.addressEndpoint}/${id}`;
    return this.httpClient.put<UpdatedAddressResponse>(url, data);
  }

  deleteAddress(id: string): Observable<DeletedAddressResponse> {
    const url = `${this.apiUrl}${this.addressEndpoint}/${id}`;
    return this.httpClient.delete<DeletedAddressResponse>(url);
  }

  getListAddress(): Observable<GetListAddressResponse[]> {
    const url = `${this.apiUrl}${this.addressEndpoint}`;
    return this.httpClient.get<GetListAddressResponse[]>(url);
  }
}
