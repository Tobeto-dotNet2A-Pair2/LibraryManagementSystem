import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PageRequest } from '../../../../core/models/page/page-request';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialListHomeService } from '../../../services/concretes/material-list-home.service';
import { AuthService } from '../../../../core/services/concretes/auth.service';
import { BorrowMaterialService } from '../../../services/concretes/borrow-material.service';
import { BorrowMaterialRequest } from '../../../models/requests/borrowed-materials/borrow-material-request';
import { BorrowMaterialResponse } from '../../../models/responses/borrowed-materials/borrow-material-response';
import { MaterialCopyListItemDto } from '../../../models/responses/material-copies/materialcopy-list-item-dto';




@Component({
  selector: 'app-material-list-home',
  standalone: true,
  imports: [CommonModule , FormsModule, RouterModule],
  templateUrl: './material-list-home.component.html',
  styleUrl: './material-list-home.component.scss'
})
export class MaterialListHomeComponent implements OnInit {

  //
  searchText: string = '';
  selectedMaterialCopyId: string = ''; // Seçilen materyal kopyası kimliği

  currentPageNumber: number = 1; 
  readonly PAGE_SIZE=2;

  materialCopyId!:string;
  material!:string;
  materialCopyList: MaterialCopyListItemDto={
    index:0,
    size:0,
    count:0,
    hasNext:false,
    hasPrevious:false,
    pages:0,
    items:[]
  };
 
  constructor(
    private materialListHomeService: MaterialListHomeService, 
    private authService: AuthService,
    private borrowMaterialService: BorrowMaterialService,
    private activatedRoute:ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}
 
  
  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      const searchText = params['q'];
      console.log("Search text:", searchText);
      if (searchText) {
        this.searchText = searchText;
        this.getMaterialListBySearchTerm(this.searchText);
        console.log("if ıcınde:::"+searchText);
      } else {
        this.getList({pageIndex:0,pageSize:this.PAGE_SIZE});
        console.log("else ıcınde");
      }
  });
}  

getMaterialListBySearchTerm(searchText: string): void {
  console.log("Search metodun içinde ");
  this.materialListHomeService.search({ pageIndex: 0, pageSize: 2 }, searchText)
    .subscribe((response: MaterialCopyListItemDto) => {
      this.materialCopyList = response;
      this.updateCurrentPageNumber();
    });
}
  
 // search baglı yapmassa  tüm listeyi getir
  
  getList(pageRequest:PageRequest){
    this.materialListHomeService.getList(pageRequest).subscribe((response: MaterialCopyListItemDto)=>{
      this.materialCopyList=response;
      console.log(this.materialCopyList)
      this.updateCurrentPageNumber(); 
    })}
    
  getMaterialListByModel(pageRequest:PageRequest,modelId:string){
    this.materialListHomeService.getMaterialListByModelId(pageRequest,modelId).subscribe((response)=>{
      this.materialCopyList=response;
      this.updateCurrentPageNumber();
    })
  }
  onViewMoreClicked():void{
    const nextPageIndex = this.materialCopyList.index+1;
    const pageSize = this.materialCopyList.size;

    this.getList({pageIndex:nextPageIndex,pageSize})
    this.updateCurrentPageNumber();
   
  }//Sonraki sayfaya gitme fonksiyonu
  onPreviousPageClicked():void{
    const previousPageIndex = this.materialCopyList.index-1;
    const pageSize = this.materialCopyList.size;
    this.getList({pageIndex:previousPageIndex,pageSize});
    this.updateCurrentPageNumber();
    console.log("current"+this.currentPageNumber)
  }//Önceki sayfaya git

  updateCurrentPageNumber():void{
    this.currentPageNumber=this.materialCopyList.index+1;
  }

  isPreviousDisabled(): boolean {
    return !this.materialCopyList.hasPrevious;
  }//Eğer önceki sayfa yoksa disabled classı ekle

  isNextDisabled(): boolean {
    return !this.materialCopyList.hasNext;
  }//Eğer sonraki sayfa yoksa butonu disabled yap

  getPageNumbers(): number[] {
    const totalPages = this.materialCopyList.pages; // Toplam sayfa sayısı
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

onMaterialClick(materialCopyId: string): void {
  debugger
  // Seçilen materyalin kopyası kimliğini ayarla
  this.selectedMaterialCopyId = materialCopyId;
  console.log("onMaterialClick"+ materialCopyId);
  this.borrowMaterial();
}

borrowMaterial(): void {
  // Kullanıcının oturum durumunu kontrol et
  debugger
  const isLoggedIn = this.authService.isLoggedIn();
  if (isLoggedIn && this.selectedMaterialCopyId) {
    // Oturumlu ise, materyal ödünç alma işlemini gerçekleştir
    const userId = this.authService.getCurrentUserId(); // Kullanıcının kimliğini al
    const materialCopyId = this.selectedMaterialCopyId; // Seçilen materyal kopyası kimliğini al
    
    this.borrowMaterialProcess(userId, materialCopyId);
    
  } else {
    // Oturumlu değilse, kullanıcıyı giriş yapmaya yönlendir veya bir bildirim göster
      
     this.router.navigate(['/auth']);// Giriş yapma sayfasına yönlendir

     this.toastr.warning('Ödünç almak için giriş yapmalısınız.', 'Uyarı');
  }
}

private borrowMaterialProcess(userId: string, materialCopyId: string): void {

  const request: BorrowMaterialRequest = { userId, materialCopyId }; 
  // Materyal ödünç alma işlemini gerçekleştir
 
  this.borrowMaterialService.borrowMaterial(request).subscribe(
    (response: BorrowMaterialResponse) => {
    
      console.log('servise gitti', response);
      this.toastr.info('Ödünç aldı.', 'İnfo');
    },
    (error) => {
      this.toastr.error('Hata aldı.', 'Error');
    }
  );

}

}
