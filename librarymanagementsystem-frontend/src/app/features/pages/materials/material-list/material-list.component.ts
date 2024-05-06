import { Component, OnInit } from '@angular/core';
import { MaterialListDto } from '../../../models/responses/materials/material-list-item-dto';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { MaterialListService } from '../../../services/concretes/material-list.service';
import { PageRequest } from '../../../../core/models/page/page-request';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UpdateMaterialRequest } from '../../../models/requests/materials/update-material-request';
import { DeleteMaterialRequest } from '../../../models/requests/materials/delete-material-request';
import { MaterialDetailDto } from '../../../models/responses/materials/material-detail-dto';
import { DeletedMaterialResponse } from '../../../models/responses/materials/deleted-material-response';
import { ToastrService } from 'ngx-toastr';




@Component({
  selector: 'app-material-list',
  standalone: true,
  imports: [CommonModule , FormsModule, RouterModule],
  templateUrl: './material-list.component.html',
  styleUrl: './material-list.component.scss'
})
export class MaterialListComponent implements OnInit {
  currentPageNumber!:number; //null
  material!:string;
  materialList: MaterialListDto={
    index:0,
    size:0,
    count:0,
    hasNext:false,
    hasPrevious:false,
    pages:0,
    items:[]
  };
 
  constructor(
    private materialListService: MaterialListService, 
    private activatedRoute:ActivatedRoute,
    private toastr: ToastrService
  ) {}
  readonly PAGE_SIZE=2;
  
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["modelId"]){
        this.getMaterialListByModel({pageIndex:0,pageSize:this.PAGE_SIZE},params["modelId"])
      }else{this.getList({pageIndex:0,pageSize:this.PAGE_SIZE})}
    })
   
  }
  getList(pageRequest:PageRequest){
    this.materialListService.getList(pageRequest).subscribe((response)=>{
      this.materialList=response;
      console.log(this.materialList)
      this.updateCurrentPageNumber();
     
    })
    
  }
  getMaterialListByModel(pageRequest:PageRequest,modelId:string){
    this.materialListService.getMaterialListByModelId(pageRequest,modelId).subscribe((response)=>{
      this.materialList=response;
      this.updateCurrentPageNumber();
    })
  }

  onViewMoreClicked():void{
    const nextPageIndex = this.materialList.index+1;
    const pageSize = this.materialList.size;

    this.getList({pageIndex:nextPageIndex,pageSize})
    this.updateCurrentPageNumber();
   
  }//Sonraki sayfaya gitme fonksiyonu
  onPreviousPageClicked():void{
    const previousPageIndex = this.materialList.index-1;
    const pageSize = this.materialList.size;
    this.getList({pageIndex:previousPageIndex,pageSize});
    this.updateCurrentPageNumber();
    console.log("current"+this.currentPageNumber)
  }//Önceki sayfaya git

  updateCurrentPageNumber():void{
    this.currentPageNumber=this.materialList.index+1;
  }

  isPreviousDisabled(): boolean {
    return !this.materialList.hasPrevious;
  }//Eğer önceki sayfa yoksa disabled classı ekle

  isNextDisabled(): boolean {
    return !this.materialList.hasNext;
  }//Eğer sonraki sayfa yoksa butonu disabled yap

  getPageNumbers(): number[] {
    const totalPages = this.materialList.pages; // Toplam sayfa sayısı
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

//-----------------------------------------------------------

  updateMaterial(material: UpdateMaterialRequest): void {
    // Güncelleme işlemi burada yapılacak
  }

  // Ayrıntıları görme işlemini gerçekleştiren metod
  // viewDetails(): void {
   
  // }

  
// onDeleteMaterial 
onDeleteMaterial(materialId: string): void {
  this.materialListService.deleteMaterial(materialId).subscribe(
    () => {
      this.toastr.success('Materyal başarılı bir şekilde silindi.', 'Başarılı');
      console.log( "materiyal silidi.");
      this.getList({ pageIndex: this.materialList.index, pageSize: this.PAGE_SIZE });
    },
    (error) => {
      console.error('Silme hatası:', error);
      this.toastr.error('Materyal silinirken bir hata oluştu.', 'Hata');
    }
  );
}
}