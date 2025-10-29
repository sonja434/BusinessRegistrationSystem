import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { isPlatformBrowser } from '@angular/common';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CompanyRequestService {

  private apiUrl = 'https://localhost:7033/api/CompanyRequests';

  constructor(
    private http: HttpClient,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  private isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  private getHeaders() {
    if (!this.isBrowser()) return {};
    const token = localStorage.getItem('authToken');
    return {
      headers: {
        Authorization: `Bearer ${token}`
      }
    };
  }

  createRequest(formData: FormData): Observable<any> {
    return this.http.post(`${this.apiUrl}`, formData, this.getHeaders());
  }

  updateRequestByUser(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/user/${id}`, data, this.getHeaders());
  }

  updateRequestByAdmin(id: number, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/admin/${id}`, data, this.getHeaders());
  }

  getUserRequests(queryParams: any = {}): Observable<any> {
    let params = new HttpParams();
    Object.keys(queryParams).forEach(key => {
      if (queryParams[key] !== undefined && queryParams[key] !== null)
        params = params.set(key, queryParams[key]);
    });

    return this.http.get(`${this.apiUrl}/user`, { ...this.getHeaders(), params });
  }

  getAllRequests(queryParams: any = {}): Observable<any> {
    let params = new HttpParams();
    Object.keys(queryParams).forEach(key => {
      if (queryParams[key] !== undefined && queryParams[key] !== null)
        params = params.set(key, queryParams[key]);
    });

    return this.http.get(`${this.apiUrl}/admin`, { ...this.getHeaders(), params });
  }

  getRequest(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`, this.getHeaders());
  }

  downloadRequestPdf(id: number): Observable<Blob> {
    return this.http.get(`${this.apiUrl}/user/${id}/pdf`, {
      ...this.getHeaders(),
      responseType: 'blob'
    });
  }

  downloadDocument(requestId: number, fileName: string): Observable<Blob> {
    return this.http.get(`${this.apiUrl}/${requestId}/documents/${fileName}`, {
      ...this.getHeaders(),
      responseType: 'blob'
    });
  }
}
