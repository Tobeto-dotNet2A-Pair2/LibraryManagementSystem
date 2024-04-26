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
  // override getList(): Observable<GetListAddressResponse[]> {
  //   throw new Error('Method not implemented.');
  // }
  // override getById(): Observable<GetByIdAddressResponse> {
  //   throw new Error('Method not implemented.');
  // }

}