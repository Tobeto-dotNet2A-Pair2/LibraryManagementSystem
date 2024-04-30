import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { CreateLibraryRequest } from '../../models/requests/libraries/create-library-request';
import { CreatedLibraryResponse } from '../../models/responses/libraries/created-library-response';
import { Observable, catchError, throwError } from 'rxjs';
import { UpdatedLibraryResponse } from '../../models/responses/libraries/updated-library-response';
import { GetListLibraryResponse } from '../../models/responses/libraries/get-list-library-response';
import { DeleteLibraryRequest } from '../../models/requests/libraries/delete-library-request';
import { DeletedLibraryResponse } from '../../models/responses/libraries/deleted-library-response';
import { GetByIdLibraryResponse } from '../../models/responses/libraries/get-by-id-library-response';
import { UpdateLibraryRequest } from '../../models/requests/libraries/update-library-request';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {
  
  private  apiUrl:string = `${environment.API_URL}/Libraries`;

  constructor(
    private httpClient:HttpClient,
    private toastr: ToastrService
  ) { }

    

  addLibrary(createLibraryRequest: CreateLibraryRequest)
      :Observable<CreatedLibraryResponse> {

        return this.httpClient.post<CreatedLibraryResponse>(`${this.apiUrl}`, createLibraryRequest).pipe(
         
          catchError((error) => {
            // Hata durumunda toastr ile hata mesajını kullanıcıya göster
            this.toastr.error("Beklenmeyen bir hata oluştu.", "Hatalı");
            // Hata mesajını konsola yazdır
            console.error(error);
            return throwError(error);
          })
        );
      }
/* Testi Daha yapılmadı
      deleteLibrary(deleteLibraryRequest: DeleteLibraryRequest): Observable<DeletedLibraryResponse> {
        return this.httpClient.delete<DeletedLibraryResponse>(`${this.apiUrl}/${deleteLibraryRequest.id}`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while deleting the library.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }
    
      getAllLibraries(): Observable<GetListLibraryResponse[]> {
        return this.httpClient.get<GetListLibraryResponse[]>(`${this.apiUrl}`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the list of libraries.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }
    
      getLibraryById(id: string): Observable<GetByIdLibraryResponse> {
        return this.httpClient.get<GetByIdLibraryResponse>(`${this.apiUrl}/${id}`).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while fetching the library details.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }
    
      updateLibrary(updateLibraryRequest: UpdateLibraryRequest): Observable<UpdatedLibraryResponse> {
        return this.httpClient.put<UpdatedLibraryResponse>(`${this.apiUrl}/${updateLibraryRequest.id}`, updateLibraryRequest).pipe(
          catchError((error) => {
            this.toastr.error("An unexpected error occurred while updating the library.", "Error");
            console.error(error);
            return throwError(error);
          })
        );
      }
      */
    }