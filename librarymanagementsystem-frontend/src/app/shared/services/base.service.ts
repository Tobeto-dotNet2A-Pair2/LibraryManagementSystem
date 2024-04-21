import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService {

  constructor(private httpClient: HttpClient) {}

  protected get<T>(url: string): Observable<T> {
    return this.httpClient.get<T>(url);
  }

  protected post<T>(url: string, data: any): Observable<T> {
    return this.httpClient.post<T>(url, data);
  }

  protected put<T>(url: string, data: any): Observable<T> {
    return this.httpClient.put<T>(url, data);
  }

  protected delete<T>(url: string): Observable<T> {
    return this.httpClient.delete<T>(url);
  }
}