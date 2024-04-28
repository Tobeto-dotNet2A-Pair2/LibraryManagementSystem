import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberListDto } from '../../../models/responses/members/member-list-item-dto';
import { MembersService } from '../../../../core/services/concretes/members.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { PageRequest } from '../../../../core/models/page/page-request';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [CommonModule , FormsModule, RouterModule],
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
  readonly PAGE_SIZE=10;
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["modelId"]){
        this.getMemberListByModel({pageIndex:0,pageSize:this.PAGE_SIZE},params["modelId"])
      }else{this.getList({pageIndex:0,pageSize:this.PAGE_SIZE})}
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

    this.getList({pageIndex:nextPageIndex,pageSize})
    this.updateCurrentPageNumber();
   
  }//Sonraki sayfaya gitme fonksiyonu
  onPreviousPageClicked():void{
    const previousPageIndex = this.memberList.index-1;
    const pageSize = this.memberList.size;
    this.getList({pageIndex:previousPageIndex,pageSize});
    this.updateCurrentPageNumber();
    console.log("current"+this.currentPageNumber)
  }//Önceki sayfaya git

  updateCurrentPageNumber():void{
    this.currentPageNumber=this.memberList.index+1;
  }

  isPreviousDisabled(): boolean {
    return !this.memberList.hasPrevious;
  }//Eğer önceki sayfa yoksa disabled classı ekle

  isNextDisabled(): boolean {
    return !this.memberList.hasNext;
  }//Eğer sonraki sayfa yoksa butonu disabled yap

  getPageNumbers(): number[] {
    const totalPages = this.memberList.pages; // Toplam sayfa sayısı
    const pageNumbers: number[] = [];
    for (let i = 1; i <= totalPages; i++) {
      pageNumbers.push(i);
    }
    return pageNumbers;
  }//Sayfa sayılarını listeleme

  onPageClicked(pageNumber: number): void {
  
    this.getList({ pageIndex: pageNumber - 1, pageSize: this.PAGE_SIZE });
    this.updateCurrentPageNumber();
  }  // Sayfa numarasına göre ilgili sayfayı getir

  onPageSizeChange(): void {
    
    this.getList({ pageIndex: 0, pageSize: this.PAGE_SIZE });
  }// Sayfa boyutu değiştiğinde, veri listesini yeniden yükle
}
