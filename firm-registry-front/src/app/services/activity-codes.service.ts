import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { isPlatformBrowser } from '@angular/common';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ActivityCodesService {
  private apiUrl = 'https://localhost:7033/api/activities'; 

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
    return token
      ? { headers: { Authorization: `Bearer ${token}` } }
      : {};
  }

  getSectors(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/sectors`, this.getHeaders());
  }

  getGroups(sectorId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/groups?sectorId=${sectorId}`, this.getHeaders());
  }

  getCodes(
    pageNumber: number,
    pageSize: number,
    search?: string,
    sectorId?: number | null,
    groupId?: number | null
  ): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber)
      .set('pageSize', pageSize);

    if (search) params = params.set('search', search);
    if (sectorId) params = params.set('sectorId', sectorId);
    if (groupId) params = params.set('groupId', groupId);

    return this.http.get<any>(`${this.apiUrl}/codes/paged`, {
      params,
      ...this.getHeaders()
    });
  }
}
