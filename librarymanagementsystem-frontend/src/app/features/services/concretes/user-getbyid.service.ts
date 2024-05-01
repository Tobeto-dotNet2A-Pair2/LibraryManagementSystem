import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserGetByIdResponse } from '../../models/responses/users/user-getbyid';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserGetbyidService {

 
  constructor(private httpClient: HttpClient) { }

  getUserById(userById: string): Observable<UserGetByIdResponse> {
    return this.httpClient.get<UserGetByIdResponse>(`${environment.API_URL}/Users/${userById}`);
  }
}
