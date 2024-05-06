import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { GetListMaterialResponse } from '../../models/responses/materials/get-list-material-response';
import { CreatedMaterialResponse } from '../../models/responses/materials/created-material-response';
import { CreateMaterialRequest } from '../../models/requests/materials/create-material-request';
import { environment } from '../../../../environments/environment';
import { ToastrService } from 'ngx-toastr';
import { GetListBranchResponse } from '../../models/responses/branches/get-list-branch-response';
import { GetListLocationResponse } from '../../models/responses/locations/get-list-location-response';
import { CreateMaterialCopyRequest } from '../../models/requests/material-copies/create-material-copy-request';
import { CreatedMaterialCopyResponse } from '../../models/responses/material-copies/created-material-copy-response';
import { CreateLocationRequest } from '../../models/requests/locations/create-location-request';
import { CreatedLocationResponse } from '../../models/responses/locations/created-location-response';
import { CreateAuthorRequest } from '../../models/requests/authors/create-author-request';
import { CreatedAuthorResponse } from '../../models/responses/authors/created-author-response';
import { CreatePublisherRequest } from '../../models/requests/publishers/create-publisher-request';
import { CreatedPublisherResponse } from '../../models/responses/publishers/created-publisher-response';
import { CreatedTranslatorResponse } from '../../models/responses/translators/created-translator-response';
import { CreateTranslatorRequest } from '../../models/requests/translators/create-translator-request';
import { CreatedLanguageResponse } from '../../models/responses/languages/created-language-response';
import { CreateLanguageRequest } from '../../models/requests/languages/create-language-request';
import { GetListAuthorResponse } from '../../models/responses/authors/get-list-author-response';
import { GetListPublisherResponse } from '../../models/responses/publishers/get-list-publisher-response';
import { GetListTranslatorResponse } from '../../models/responses/translators/get-list-translator-response';
import { GetListLanguageResponse } from '../../models/responses/languages/get-list-language-response';
import { CreateAuthorMaterialRequest } from '../../models/requests/authorMaterials/create-authorMaterial-request';
import { CreatedAuthorMaterialResponse } from '../../models/responses/authorMaterials/created-authorMaterial-response';
import { CreateLanguageMaterialRequest } from '../../models/requests/languageMaterials/create-languageMaterial-request';
import { CreatedLanguageMaterialResponse } from '../../models/responses/languageMaterial/created-languageMaterial-response';
import { CreatePublisherMaterialRequest } from '../../models/requests/publisherMaterials/create-publisherMaterial-request';
import { CreatedPublisherMaterialResponse } from '../../models/responses/publisherMaterials/created-publisherMaterial-response';
import { CreateTranslatorMaterialRequest } from '../../models/requests/translatorMaterials/create-translatorMaterial-request';
import { CreatedTranslatorMaterialResponse } from '../../models/responses/translatorMaterials/created-translatorMaterial-response';

@Injectable({
  providedIn: 'root'
})
export class MaterialManagementService  {
  private readonly materialApiUrl = `${environment.API_URL}/Materials`;
  private readonly materialCopyApiUrl = `${environment.API_URL}/MaterialCopies`;
  private readonly branchApiUrl = `${environment.API_URL}/Branches`;
  private readonly locationApiUrl = `${environment.API_URL}/Locations`;
  private readonly authorApiUrl = `${environment.API_URL}/Authors`;
  private readonly publisherApiUrl = `${environment.API_URL}/Publishers`;
  private readonly translatorApiUrl = `${environment.API_URL}/Translators`;
  private readonly languageApiUrl = `${environment.API_URL}/Languages`;
  private readonly authorMaterialApiUrl = `${environment.API_URL}/AuthorMaterials`;
  private readonly languageMaterialApiUrl = `${environment.API_URL}/LanguageMaterials`;
  private readonly publisherMaterialApiUrl = `${environment.API_URL}/PublisherMaterials`;
  private readonly translatorMaterialApiUrl = `${environment.API_URL}/TranslatorMaterials`;

  constructor(
    private httpClient:HttpClient,
    private toastr: ToastrService
  ) { }

    
//Add
   addMaterial(createMaterialRequest: CreateMaterialRequest)
      :Observable<CreatedMaterialResponse> {

        return this.httpClient.post<CreatedMaterialResponse>(`${this.materialApiUrl}`, createMaterialRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addMaterialCopy(createMaterialCopyRequest: CreateMaterialCopyRequest)
      :Observable<CreatedMaterialCopyResponse> {

        return this.httpClient.post<CreatedMaterialCopyResponse>(`${this.materialCopyApiUrl}`, createMaterialCopyRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addLocation(createLocationRequest: CreateLocationRequest)
      :Observable<CreatedLocationResponse> {

        return this.httpClient.post<CreatedLocationResponse>(`${this.locationApiUrl}`, createLocationRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addAuthor(createAuthorRequest: CreateAuthorRequest)
      :Observable<CreatedAuthorResponse> {

        return this.httpClient.post<CreatedAuthorResponse>(`${this.authorApiUrl}`, createAuthorRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addPublisher(createPublisherRequest: CreatePublisherRequest)
      :Observable<CreatedPublisherResponse> {

        return this.httpClient.post<CreatedPublisherResponse>(`${this.publisherApiUrl}`, createPublisherRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addTranslator(createTranslatorRequest: CreateTranslatorRequest)
      :Observable<CreatedTranslatorResponse> {

        return this.httpClient.post<CreatedTranslatorResponse>(`${this.translatorApiUrl}`, createTranslatorRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addLanguage(createLanguageRequest: CreateLanguageRequest)
      :Observable<CreatedLanguageResponse> {

        return this.httpClient.post<CreatedLanguageResponse>(`${this.languageApiUrl}`, createLanguageRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }
//Ara Tablo
addAuthorMaterial(createAuthorMaterialRequest: CreateAuthorMaterialRequest)
      :Observable<CreatedAuthorMaterialResponse> {

        return this.httpClient.post<CreatedAuthorMaterialResponse>(`${this.authorMaterialApiUrl}`, createAuthorMaterialRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addLanguageMaterial(createLanguageMaterialRequest: CreateLanguageMaterialRequest)
      :Observable<CreatedLanguageMaterialResponse> {

        return this.httpClient.post<CreatedLanguageMaterialResponse>(`${this.languageMaterialApiUrl}`, createLanguageMaterialRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addPublisherMaterial(createPublisherMaterialRequest: CreatePublisherMaterialRequest)
      :Observable<CreatedPublisherMaterialResponse> {

        return this.httpClient.post<CreatedPublisherMaterialResponse>(`${this.publisherMaterialApiUrl}`, createPublisherMaterialRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }

      addTranslatorMaterial(createTranslatorMaterialRequest: CreateTranslatorMaterialRequest)
      :Observable<CreatedTranslatorMaterialResponse> {

        return this.httpClient.post<CreatedTranslatorMaterialResponse>(`${this.translatorMaterialApiUrl}`, createTranslatorMaterialRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }



//GetAll

      getAllMaterials(): Observable<GetListMaterialResponse[]> {
        return this.httpClient.get<GetListMaterialResponse[]>(`${this.materialApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Materials.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllBranches(): Observable<GetListBranchResponse[]> {
        return this.httpClient.get<GetListBranchResponse[]>(`${this.branchApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Branches.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllLocations(): Observable<GetListLocationResponse[]> {
        return this.httpClient.get<GetListLocationResponse[]>(`${this.locationApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Locations.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllAuthors(): Observable<GetListAuthorResponse[]> {
        return this.httpClient.get<GetListAuthorResponse[]>(`${this.authorApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Authors.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllPublishers(): Observable<GetListPublisherResponse[]> {
        return this.httpClient.get<GetListPublisherResponse[]>(`${this.publisherApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Publishers.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllTranslators(): Observable<GetListTranslatorResponse[]> {
        return this.httpClient.get<GetListTranslatorResponse[]>(`${this.translatorApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Translators.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }

      getAllLanguages(): Observable<GetListLanguageResponse[]> {
        return this.httpClient.get<GetListLanguageResponse[]>(`${this.languageApiUrl}/GetAll`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of Languages.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }
 

}
