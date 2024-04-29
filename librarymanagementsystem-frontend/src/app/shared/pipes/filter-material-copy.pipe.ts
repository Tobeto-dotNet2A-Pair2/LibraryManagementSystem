import { Pipe, PipeTransform } from '@angular/core';
import { GetListMaterialCopyResponse } from '../../features/models/responses/material-copies/get-list-material-copy-response';

@Pipe({
  name: 'filterMaterialCopy',
  pure : false
})
export class FilterMaterialCopyPipe implements PipeTransform {

  transform(value: GetListMaterialCopyResponse[], filterText: string): GetListMaterialCopyResponse[] {
    if(!value || !filterText) {
     return value;
    }
    const searchText = filterText.toLowerCase();
    return value.filter(materialCopy =>{
      const materialName = materialCopy.materialId.toLowerCase();
      return materialName.includes(searchText);
    })

}}
