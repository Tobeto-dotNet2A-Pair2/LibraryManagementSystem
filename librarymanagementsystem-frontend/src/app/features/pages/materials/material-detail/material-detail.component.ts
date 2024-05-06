import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Author, Genre, Language, MaterialCopy, MaterialDetailDto, MaterialProperty, Publisher, Translator } from '../../../models/responses/materials/material-detail-dto';
import { MaterialGetbyidService } from '../../../services/concretes/material-getbyid.service';

@Component({
  selector: 'app-material-detail',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './material-detail.component.html',
  styleUrl: './material-detail.component.scss'
})
export class MaterialDetailComponent implements OnInit {
  materialId!: string;
  materialDetail: MaterialDetailDto[] = [];

  //-----
  authors: Author[] = [];
  publishers: Publisher[] = [];
  languages: Language[] = [];
  translators: Translator[] = [];
  materialCopies: MaterialCopy[] = [];
  genres: Genre[] = [];
  materialProperties: MaterialProperty[] = [];


  constructor(
    private route: ActivatedRoute,
    private materialGetByIdService: MaterialGetbyidService
  ) {}
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.materialId = params['id'];
      this.getMaterialById();
   
    });
  }
  getMaterialById(): void {
    this.materialGetByIdService.getMaterialById(this.materialId).subscribe({
      next: (response: MaterialDetailDto) => {
        console.log('Backendden cevap geldi:', response);

        // this.materialByIdList = [response];
        this.materialDetail = [response];
        this.authors = response.authors;
        this.publishers = response.publishers;
        this.languages = response.languages;
        this.translators = response.translators;
        this.materialCopies = response.materialCopies;
        this.genres = response.genres;
        this.materialProperties = response.materialProperties;

        
      },
              error: (error) => {
                console.log('Backendden hatalı cevap geldi:', error);
              },
              complete: () => {
                console.log('Backend isteği sonlandı.');
              },
            });
        
          }}
