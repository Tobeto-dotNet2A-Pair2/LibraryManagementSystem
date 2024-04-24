import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';
import { CreatedAddressResponse } from '../../models/responses/addresses/created-address-response';
import { UpdatedAddressResponse } from '../../models/responses/addresses/updated-address-response';
import { DeletedAddressResponse } from '../../models/responses/addresses/deleted-address-response';
import { GetListAddressResponse } from '../../models/responses/addresses/get-list-address-response';
import { AddressBaseService } from '../abstracts/address-base.service';

@Injectable({
  providedIn: 'root'
})


export class AddressService extends AddressBaseService 
 {

  constructor(httpClient: HttpClient) {
    //
    super(httpClient);
  }
  
  // override getAddressById(id: string): Observable<GetByIdAddressResponse> {

  //   return this.httpClient.get<GetByIdAddressResponse>('/api/Addresses/${id}');
    
  // }
  // override createAddress(data: any): Observable<CreatedAddressResponse> {
  //   return this.post<CreatedAddressResponse>('/api/Addresses', data);

 
  // }
  // override updateAddress(id: string, data: any): Observable<UpdatedAddressResponse> {
  //   return this.put<UpdatedAddressResponse>(`/api/Addresses/$/{id}`, data);

  // }
  // override deleteAddress(id: string): Observable<DeletedAddressResponse> {
  //   return this.delete<DeletedAddressResponse>(`/api/Addresses/${id}`);
    
  // }
  // override getListAddress(): Observable<GetListAddressResponse[]> {
  //   return this.get<GetListAddressResponse[]>('/api/Addresses');
  
  // }
}