
import { PageResponse } from "../../../../core/models/page/page-response";
import {GetListMaterialCopyResponse} from "./get-list-material-copy-response";

export interface MaterialCopyListItemDto extends PageResponse<GetListMaterialCopyResponse>{
    items:GetListMaterialCopyResponse[];
}