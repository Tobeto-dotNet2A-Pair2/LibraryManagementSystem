import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateMemberRequest } from '../../../models/requests/members/create-member-request';
import { environment } from '../../../../../environments/environment';
import { CreateCityRequest } from '../../../models/requests/cities/create-city-request';
import { CommonModule } from '@angular/common';
import { MemberListDto } from '../../../models/responses/members/member-list-item-dto';
import { MembersService } from '../../../../core/services/concretes/members.service';
import { ActivatedRoute } from '@angular/router';
import { PageRequest } from '../../../../core/models/page/page-request';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [CommonModule ],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.scss',
})
export class MemberListComponent implements OnInit {
  currentPageNumber!:number;
  memberList: MemberListDto={
    index:0,
    size:0,
    count:0,
    hasNext:false,
    hasPrevious:false,
    pages:0,
    items:[]
  };

  constructor(private membersService: MembersService, private activatedRoute:ActivatedRoute) {}
  readonly PAGE_SIZE=6;
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["modelId"]){
        this.getMemberListByModel({page:0,pageSize:this.PAGE_SIZE},params["modelId"])
      }else{this.getList({page:0,pageSize:this.PAGE_SIZE})}
    })
   
  }

  getList(pageRequest:PageRequest){
    this.membersService.getList(pageRequest).subscribe((response)=>{
      this.memberList=response;
      console.log(this.memberList)
      this.updateCurrentPageNumber();
    })
    
  }
  getMemberListByModel(pageRequest:PageRequest,modelId:string){
    this.membersService.getMemberListByModelId(pageRequest,modelId).subscribe((response)=>{
      this.memberList=response;
      this.updateCurrentPageNumber();
    })
  }

  onViewMoreClicked():void{
    const nextPageIndex = this.memberList.index+1;
    const pageSize = this.memberList.size;

    this.getList({page:nextPageIndex,pageSize})
    this.updateCurrentPageNumber();
  }
  onPreviousPageClicked():void{
    const previousPageIndex = this.memberList.index-1;
    const pageSize = this.memberList.size;
    this.getList({page:previousPageIndex,pageSize});
    this.updateCurrentPageNumber();
  }

  updateCurrentPageNumber():void{
    this.currentPageNumber=this.memberList.index+1;
  }
  // getMembers(): void {
  //   this.membersService.getList({ page: 0, pageSize: 10 })
  //     .subscribe({
  //       next: (response: MemberListDto[]) => {
  //         console.log('Backendden cevap geldi:', response);
  //         this.memberList = response;
  //       },
  //       error: (error) => {
  //         console.log('Backendden hatalı cevap geldi:', error);
  //       },
  //       complete: () => {
  //         console.log('Backend isteği sonlandı.');
  //       },
  //     });
  // }

  // pageIndex: number = 0;
  // pageSize: number = 10;

  // getMember() {
  //   this.httpClient
  //     .get<CreateMemberRequest[]>(
  //       `${environment.API_URL}/members?PageIndex=${this.pageIndex}&PageSize=${this.pageSize}`
  //     )
  //     .subscribe({
  //       next: (response: CreateMemberRequest[]) => {
  //         console.log('Backendden cevap geldi:', response);
  //         this.memberList = response;
          
  //       },
  //       error: (error) => {
  //         console.log('Backendden hatalı cevap geldi:', error);
  //       },
  //       complete: () => {
  //         console.log('Backend isteği sonlandı.');
  //       },
  //     });
  // }
  
}
