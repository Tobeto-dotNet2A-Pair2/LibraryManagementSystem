
import { PageResponse } from "../../../../core/models/page/page-response";
import { GetListMaterialResponse } from "./get-list-material-response";

export interface MaterialListItemDto extends PageResponse<GetListMaterialResponse>{
    items:GetListMaterialResponse[];
}