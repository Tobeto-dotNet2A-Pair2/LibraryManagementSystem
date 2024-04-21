import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../../../shared/services/base.service';
import { HttpClient } from '@angular/common/http';
import { CreatedAddressResponse } from '../../models/responses/addresses/created-address-response';
import { UpdatedAddressResponse } from '../../models/responses/addresses/updated-address-response';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';
import { GetListAddressResponse } from '../../models/responses/addresses/get-list-address-response';
import { DeletedAddressResponse } from '../../models/responses/addresses/deleted-address-response';

@Injectable({
  providedIn: 'root'
})
export abstract class AddressBaseService extends BaseService{

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

   getAddressById(id: string): Observable<GetByIdAddressResponse>{
  return this.httpClient.get<GetByIdAddressResponse>('/api/Addresses/${id}');
  }

   createAddress(data: any): Observable<CreatedAddressResponse>{
    return this.httpClient.post<CreatedAddressResponse>('/api/Addresses', data);
   }
   updateAddress(id: string, data: any): Observable<UpdatedAddressResponse>{
    return this.httpClient.put<UpdatedAddressResponse>(`/api/Addresses/$/{id}`, data);
   }
   deleteAddress(id: string): Observable<DeletedAddressResponse>{
    return this.httpClient.delete<DeletedAddressResponse>(`/api/Addresses/${id}`);
   }
   getListAddress(): Observable<GetListAddressResponse[]>{
    return this.httpClient.get<GetListAddressResponse[]>('/api/Addresses');
   }
}

