import { PageResponse } from "../../../../core/models/page/page-response";
import { GetListMaterialResponse } from "./get-list-material-response";

export interface MaterialListDto extends PageResponse{
    items:GetListMaterialResponse[]

}