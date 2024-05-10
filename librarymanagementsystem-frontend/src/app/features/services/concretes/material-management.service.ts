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
import { UpdateMaterialRequest } from '../../models/requests/materials/update-material-request';
import { UpdatedMaterialResponse } from '../../models/responses/materials/updated-material-response';
import { UpdateAuthorRequest } from '../../models/requests/authors/update-author-request';
import { UpdatedAuthorResponse } from '../../models/responses/authors/updated-author-response';
import { UpdateLocationRequest } from '../../models/requests/locations/update-location-request';
import { UpdatedLocationResponse } from '../../models/responses/locations/updated-location-response';
import { CreateMaterialImageRequest } from '../../models/requests/material-images/create-material-image-request';
import { CreatedMaterialImageResponse } from '../../models/responses/material-images/created-material-image-response';
import { CreateGenreRequest } from '../../models/requests/genres/create-genre-request';
import { CreatedGenreResponse } from '../../models/responses/genres/created-genre-response';
import { GetListGenreResponse } from '../../models/responses/genres/get-list-genre-response';
import { CreatedMaterialGenreResponse } from '../../models/responses/materialGenres/created-materialGenre-response';
import { CreateMaterialGenreRequest } from '../../models/requests/materialGenres/create-materialGenre-request';
import { CreateMaterialPropertyRequest } from '../../models/requests/material-properties/create-material-property-request';
import { CreatedMaterialPropertyResponse } from '../../models/responses/material-properties/created-material-property-response';
import { GetListMaterialPropertyResponse } from '../../models/responses/material-properties/get-list-material-property-response';
import { GetListMaterialTypeResponse } from '../../models/responses/material-types/get-list-material-type-response';
import { CreateMaterialTypeRequest } from '../../models/requests/material-types/create-material-type-request';
import { CreatedMaterialTypeResponse } from '../../models/responses/material-types/created-material-type-response';
import { CreateMaterialPropertyValueRequest } from '../../models/requests/material-property-values/create-material-property-value-request';
import { CreatedMaterialPropertyValueResponse } from '../../models/responses/material-property-values/created-material-property-value-response';

@Injectable({
  providedIn: 'root',
})
export class MaterialManagementService {
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
  private readonly materialImageApiUrl = `${environment.API_URL}/MaterialImages`;
  private readonly genreApiUrl = `${environment.API_URL}/Genres`;
  private readonly materialGenreApiUrl = `${environment.API_URL}/MaterialGenres`;
  private readonly materialPropertyApiUrl = `${environment.API_URL}/MaterialProperties`;
  private readonly materialTypeApiUrl = `${environment.API_URL}/MaterialTypes`;
  private readonly materialPropertyValueApiUrl = `${environment.API_URL}/MaterialPropertyValues`;
  constructor(private httpClient: HttpClient, private toastr: ToastrService) {}

  //Add
  addMaterial(
    createMaterialRequest: CreateMaterialRequest
  ): Observable<CreatedMaterialResponse> {
    console.log(createMaterialRequest);
    return this.httpClient
      .post<CreatedMaterialResponse>(
        `${this.materialApiUrl}/Add`,
        createMaterialRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addMaterialCopy(
    createMaterialCopyRequest: CreateMaterialCopyRequest
  ): Observable<CreatedMaterialCopyResponse> {
    return this.httpClient
      .post<CreatedMaterialCopyResponse>(
        `${this.materialCopyApiUrl}`,
        createMaterialCopyRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addLocation(
    createLocationRequest: CreateLocationRequest
  ): Observable<CreatedLocationResponse> {
    return this.httpClient
      .post<CreatedLocationResponse>(
        `${this.locationApiUrl}`,
        createLocationRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addAuthor(
    createAuthorRequest: CreateAuthorRequest
  ): Observable<CreatedAuthorResponse> {
    return this.httpClient
      .post<CreatedAuthorResponse>(`${this.authorApiUrl}`, createAuthorRequest)
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addPublisher(
    createPublisherRequest: CreatePublisherRequest
  ): Observable<CreatedPublisherResponse> {
    return this.httpClient
      .post<CreatedPublisherResponse>(
        `${this.publisherApiUrl}`,
        createPublisherRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addTranslator(
    createTranslatorRequest: CreateTranslatorRequest
  ): Observable<CreatedTranslatorResponse> {
    return this.httpClient
      .post<CreatedTranslatorResponse>(
        `${this.translatorApiUrl}`,
        createTranslatorRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addLanguage(
    createLanguageRequest: CreateLanguageRequest
  ): Observable<CreatedLanguageResponse> {
    return this.httpClient
      .post<CreatedLanguageResponse>(
        `${this.languageApiUrl}`,
        createLanguageRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addMaterialImage(
    createMaterialImageRequest: FormData
  ): Observable<CreatedMaterialImageResponse> {
    return this.httpClient
      .post<CreatedMaterialImageResponse>(
        `${this.materialImageApiUrl}/Add`,
        createMaterialImageRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          debugger;
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addGenre(
    createGenreRequest: CreateGenreRequest
  ): Observable<CreatedGenreResponse> {
    return this.httpClient
      .post<CreatedGenreResponse>(
        `${this.genreApiUrl}`,
        createGenreRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }
  //Ara Tablo
  addAuthorMaterial(
    createAuthorMaterialRequest: CreateAuthorMaterialRequest
  ): Observable<CreatedAuthorMaterialResponse> {
    return this.httpClient
      .post<CreatedAuthorMaterialResponse>(
        `${this.authorMaterialApiUrl}`,
        createAuthorMaterialRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addMaterialGenre(
    createMaterialGenreRequest: CreateMaterialGenreRequest
  ): Observable<CreatedMaterialGenreResponse> {
    return this.httpClient
      .post<CreatedMaterialGenreResponse>(
        `${this.materialGenreApiUrl}`,
        createMaterialGenreRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addMaterialProperty(
    createMaterialPropertyRequest: CreateMaterialPropertyRequest
  ): Observable<CreatedMaterialPropertyResponse> {
    return this.httpClient
      .post<CreatedMaterialPropertyResponse>(
        `${this.materialPropertyApiUrl}/Add`,
        createMaterialPropertyRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addMaterialPropertyValue(
    createMaterialPropertyValueRequest: CreateMaterialPropertyValueRequest
  ): Observable<CreatedMaterialPropertyValueResponse> {
    return this.httpClient
      .post<CreatedMaterialPropertyValueResponse>(
        `${this.materialPropertyValueApiUrl}`,
        createMaterialPropertyValueRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addMaterialType(
    createMaterialTypeRequest: CreateMaterialTypeRequest
  ): Observable<CreatedMaterialTypeResponse> {
    return this.httpClient
      .post<CreatedMaterialTypeResponse>(
        `${this.materialTypeApiUrl}`,
        createMaterialTypeRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addLanguageMaterial(
    createLanguageMaterialRequest: CreateLanguageMaterialRequest
  ): Observable<CreatedLanguageMaterialResponse> {
    return this.httpClient
      .post<CreatedLanguageMaterialResponse>(
        `${this.languageMaterialApiUrl}`,
        createLanguageMaterialRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addPublisherMaterial(
    createPublisherMaterialRequest: CreatePublisherMaterialRequest
  ): Observable<CreatedPublisherMaterialResponse> {
    return this.httpClient
      .post<CreatedPublisherMaterialResponse>(
        `${this.publisherMaterialApiUrl}`,
        createPublisherMaterialRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  addTranslatorMaterial(
    createTranslatorMaterialRequest: CreateTranslatorMaterialRequest
  ): Observable<CreatedTranslatorMaterialResponse> {
    return this.httpClient
      .post<CreatedTranslatorMaterialResponse>(
        `${this.translatorMaterialApiUrl}`,
        createTranslatorMaterialRequest
      )
      .pipe(
        catchError((error) => {
          // Hata durumunda toastr ile hata mesajını kullanıcıya göster
          this.toastr.error('Beklenmeyen bir hata oluştu.', 'Hatalı');
          // Hata mesajını konsola yazdır
          console.error(error);
          return throwError(error);
        })
      );
  }

  //UPDATE
  updateMaterial(
    updateMaterialRequest: UpdateMaterialRequest
  ): Observable<UpdatedMaterialResponse> {
    return this.httpClient
      .put<UpdatedMaterialResponse>(
        `${this.materialApiUrl}/Update`,
        updateMaterialRequest
      )
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while updating the Material.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  updateAuthor(
    updateAuthorRequest: UpdateAuthorRequest
  ): Observable<UpdatedAuthorResponse> {
    return this.httpClient
      .put<UpdatedAuthorResponse>(
        `${this.authorApiUrl}`,
        updateAuthorRequest
      )
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while updating the Author.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  updateLocation(
    updateLocationRequest: UpdateLocationRequest
  ): Observable<UpdatedLocationResponse> {
    return this.httpClient
      .put<UpdatedLocationResponse>(
        `${this.locationApiUrl}`,
        updateLocationRequest
      )
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while updating the Location.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  //GetAll

  getAllMaterials(): Observable<GetListMaterialResponse[]> {
    return this.httpClient
      .get<GetListMaterialResponse[]>(`${this.materialApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Materials.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllBranches(): Observable<GetListBranchResponse[]> {
    return this.httpClient
      .get<GetListBranchResponse[]>(`${this.branchApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Branches.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllLocations(): Observable<GetListLocationResponse[]> {
    return this.httpClient
      .get<GetListLocationResponse[]>(`${this.locationApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Locations.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllAuthors(): Observable<GetListAuthorResponse[]> {
    return this.httpClient
      .get<GetListAuthorResponse[]>(`${this.authorApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Authors.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllPublishers(): Observable<GetListPublisherResponse[]> {
    return this.httpClient
      .get<GetListPublisherResponse[]>(`${this.publisherApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Publishers.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllTranslators(): Observable<GetListTranslatorResponse[]> {
    return this.httpClient
      .get<GetListTranslatorResponse[]>(`${this.translatorApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Translators.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllLanguages(): Observable<GetListLanguageResponse[]> {
    return this.httpClient
      .get<GetListLanguageResponse[]>(`${this.languageApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Languages.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllGenres(): Observable<GetListGenreResponse[]> {
    return this.httpClient
      .get<GetListGenreResponse[]>(`${this.genreApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of Genres.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllMaterialProperties(): Observable<GetListMaterialPropertyResponse[]> {
    return this.httpClient
      .get<GetListMaterialPropertyResponse[]>(`${this.materialPropertyApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of MaterialProperties.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }

  getAllMaterialTypes(): Observable<GetListMaterialTypeResponse[]> {
    return this.httpClient
      .get<GetListMaterialTypeResponse[]>(`${this.materialTypeApiUrl}/GetAll`)
      .pipe(
        catchError((error) => {
          this.toastr.error(
            'An unexpected error occurred while fetching the list of MaterialTypes.',
            'Error'
          );
          console.error(error);
          return throwError(error);
        })
      );
  }


}
