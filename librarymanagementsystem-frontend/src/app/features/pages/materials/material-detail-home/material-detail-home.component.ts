import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Author, Genre, Language, MaterialCopy, MaterialDetailDto, MaterialImage, MaterialProperty, Publisher, Translator } from '../../../models/responses/materials/material-detail-dto';
import { ActivatedRoute } from '@angular/router';
import { MaterialGetbyidService } from '../../../services/concretes/material-getbyid.service';
import { MaterialDetailHomeDto } from '../../../models/responses/materials/material-detail-home-dto';

@Component({
  selector: 'app-material-detail-home',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './material-detail-home.component.html',
  styleUrl: './material-detail-home.component.scss'
})
export class MaterialDetailHomeComponent implements OnInit {
  @Input() materialCopyId!: string;
  materialHomeDetail: MaterialDetailHomeDto  | undefined;
  authors: Author[] = [];
  publishers: Publisher[] = [];
  languages: Language[] = [];
  translators: Translator[] = [];
  materialCopies: MaterialCopy[] = [];
  genres: Genre[] = [];
  materialProperties: MaterialProperty[] = [];
  materialImages: MaterialImage[] = [];

  constructor(
    private route: ActivatedRoute,
    private materialGetByIdService: MaterialGetbyidService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.materialCopyId = params['id'];
      this.getMaterialCopyById();
    });
  }

  getMaterialCopyById(): void {
    this.materialGetByIdService.getMaterialCopyById(this.materialCopyId).subscribe({
      next: (response: MaterialDetailHomeDto) => {
        console.log('Backendden cevap geldi:', response);

           // this.materialByIdList = [response];
        this.materialHomeDetail = response;
        console.log( "material"+this.materialHomeDetail);
        this.authors = response.authors;
        this.publishers = response.publishers;
        this.languages = response.languages;
        this.translators = response.translators;
        this.materialProperties = response.materialProperties;
        this.genres = response.genres;
        this.materialImages = response.materialImages; 
      },
      error: (error) => {
        console.log('Backendden hatalı cevap geldi:', error);
      },
      complete: () => {
        console.log('Backend isteği sonlandı.');
      },
    });
  }

  

}
