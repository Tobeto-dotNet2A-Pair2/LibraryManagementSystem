import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetListAddressResponse } from '../../models/responses/addresses/get-list-address-response';
import { GetByIdAddressResponse } from '../../models/responses/addresses/get-by-id-address-response';

@Injectable({
  providedIn: 'root'
})
export abstract class AddressBaseService {

  // constructor() { }

  abstract getList(): Observable<GetListAddressResponse[]>;
  abstract getById(): Observable<GetByIdAddressResponse[]>;
}
