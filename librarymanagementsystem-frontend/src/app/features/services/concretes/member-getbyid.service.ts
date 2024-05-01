import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetByIdMemberResponse } from '../../models/responses/members/get-by-id-member-response';
import { environment } from '../../../../environments/environment';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MemberGetbyidService {

  constructor(private httpClient: HttpClient) { }

  getMemberById(memberId: string): Observable<GetByIdMemberResponse> {
    return this.httpClient.get<GetByIdMemberResponse>(`${environment.API_URL}/Members/${memberId}`);
  }
}
