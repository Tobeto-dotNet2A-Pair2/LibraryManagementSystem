import { Pipe, PipeTransform } from '@angular/core';
import { GetListMemberResponse } from '../../features/models/responses/members/get-list-member-response';

@Pipe({
  name: 'filterMemberName',
  standalone: true,

})
export class FilterMemberNamePipe implements PipeTransform {

  transform(value: GetListMemberResponse[], filterText: string): GetListMemberResponse[] {
    if (!value || !filterText) {
      return value; 
    }
  
    const searchText = filterText.toLowerCase(); 
  
    return value.filter(member => {
      const memberName = `${member.firstName}  ${member.lastName}`.toLowerCase();  
      return memberName.includes(searchText); 
    });
  }
  }

  