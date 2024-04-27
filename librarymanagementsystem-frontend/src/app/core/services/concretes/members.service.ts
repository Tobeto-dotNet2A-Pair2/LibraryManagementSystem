import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { MemberBaseService } from '../abstracts/member-base.service';
import { environment } from '../../../../environments/environment';
import { PageRequest } from '../../models/page/page-request';
import { MemberListDto } from '../../../features/models/responses/members/member-list-item-dto';

@Injectable({
  providedIn: 'root'
})
export class MembersService extends MemberBaseService {
  private readonly apiUrl:string = `${environment.API_URL}/members?PageIndex=0&PageSize=10`
  constructor(private httpClient:HttpClient) {super() }
  
  override getList(pageRequest: PageRequest): Observable<MemberListDto> {
    const newRequest :{[key:string]:string | number}={
      page:pageRequest.page,
      pageSize:pageRequest.pageSize
    };

    return this.httpClient.get<MemberListDto>(this.apiUrl,{
      params:newRequest
    }).pipe(
      map((response)=>{
        const newResponse:MemberListDto={
          index:pageRequest.page,
          size:pageRequest.pageSize,
          count:response.count,
          hasNext:response.hasNext,
          hasPrevious:response.hasPrevious,
          items:response.items,
          pages:response.pages
        };
        return newResponse;
      })
    )
  }

  
  override getMemberListByModelId(pageRequest: PageRequest,modelId:string): Observable<MemberListDto> {
    const newRequest :{[key:string]:string | number}={
      page:pageRequest.page,
      pageSize:pageRequest.pageSize,
      modelId:modelId
    };

    return this.httpClient.get<MemberListDto>(`${this.apiUrl}/getmemberbymodel`,{
      params:newRequest
    }).pipe(
      map((response)=>{
        const newResponse:MemberListDto={
          index:pageRequest.page,
          size:pageRequest.pageSize,
          count:response.count,
          hasNext:response.hasNext,
          hasPrevious:response.hasPrevious,
          items:response.items,
          pages:response.pages
        };
        return newResponse;
      })
    )
  }

}
