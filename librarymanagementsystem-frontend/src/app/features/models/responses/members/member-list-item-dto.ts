import { PageResponse } from "../../../../core/models/page/page-response";
import { GetListMemberResponse } from "./get-list-member-response";

export interface MemberListDto extends PageResponse{
    items:GetListMemberResponse[]

}