import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { BorrowMaterialRequest } from '../../models/requests/borrowed-materials/borrow-material-request';
import { Observable, catchError, map } from 'rxjs';
import { BorrowMaterialResponse } from '../../models/responses/borrowed-materials/borrow-material-response';

@Injectable({
  providedIn: 'root'
})
export class BorrowMaterialService {

  private readonly apiUrl: string = `${environment.API_URL}/BorrowMaterials`;
  constructor(
    private httpClient: HttpClient,
    private toastr: ToastrService
  ) {}

  borrowMaterial(request: BorrowMaterialRequest): Observable<BorrowMaterialResponse> {
    return this.httpClient.post<BorrowMaterialResponse>(`${this.apiUrl}/Add`, request).pipe(
      map(response => {
        this.showInfo(response); // BorrowMaterialResponse toast bildirimi
        return response;
      }),
      catchError(error => {
        this.toastr.error('İşlem Başarısız', 'Hata'); // Hata  toast bildirimi
        throw error;
      })
    );
  }

  showInfo(response: BorrowMaterialResponse) {
    const message = `Ödünç alma tarihi: ${response.borrowedDate}, Dönüş tarihi: ${response.returnDate}, Cezai miktar: ${response.punishmentAmount}`;
    this.toastr.info(message, 'Bilgi'); // BorrowMaterialResponse toast bildirimi
  }
}

