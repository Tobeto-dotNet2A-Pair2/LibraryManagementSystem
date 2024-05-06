import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';
import { CreatedAddressResponse } from '../../models/responses/addresses/created-address-response';
import { AddressBaseService } from '../abstracts/address-base.service';
import { CreateAddressRequest } from '../../models/requests/addresses/create-address-request';
import { AddressListItemDto } from '../../models/requests/addresses/address-list-item.dto';

@Injectable({
  providedIn: 'root'
})


export class AddressService extends AddressBaseService 
 {
  override getByIdCity(id: string): Observable<GetByIdAddressResponse> {
    return this.httpClient.get<GetByIdAddressResponse>(`${this.apiUrl}/${id}`);
  }


  createAddress(createAddressRequest: CreateAddressRequest<AddressListItemDto>): Observable<CreatedAddressResponse> {
        return this.httpClient.post<CreatedAddressResponse>(`${this.apiUrl}`, createAddressRequest);
      }
  
}