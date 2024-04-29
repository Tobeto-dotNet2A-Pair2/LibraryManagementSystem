import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';
import { GetListAddressResponse } from '../../models/responses/addresses/get-list-address-response';

@Injectable({
  providedIn: 'root'
})
export abstract class AddressBaseService {

  // abstract getList(): Observable<GetListAddressResponse[]>;

  // abstract getById(): Observable<GetByIdAddressResponse>;


}