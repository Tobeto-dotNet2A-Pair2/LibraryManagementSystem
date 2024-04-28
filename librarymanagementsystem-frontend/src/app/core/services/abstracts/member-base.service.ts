import { Injectable } from "@angular/core";
import { PageRequest } from "../../models/page/page-request";
import { Observable } from "rxjs";
import { MemberListDto } from "../../../features/models/responses/members/member-list-item-dto";

@Injectable()
export abstract class MemberBaseService{
    abstract getList(pageRequest:PageRequest):Observable<MemberListDto>
    abstract getMemberListByModelId(pageRequest:PageRequest,modelId:string)
    :Observable<MemberListDto>
}