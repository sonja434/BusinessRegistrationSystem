import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { isPlatformBrowser } from '@angular/common';
import { BehaviorSubject, Observable, tap } from 'rxjs';

interface LoginResponse { token: string; }

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenKey = 'authToken';
  private apiUrl = 'https://localhost:7033/api/Auth';
  private _auth$ = new BehaviorSubject<boolean>(false);

  constructor(
    private http: HttpClient,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {
    this._auth$.next(this.hasToken());
  }

  private isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  private hasToken(): boolean {
    if (!this.isBrowser()) return false;
    return !!localStorage.getItem(this.tokenKey);
  }

  register(userData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, userData);
  }

  loginUser(data: { username: string; password: string }): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, data)
      .pipe(
        tap(res => {
          if (this.isBrowser() && res?.token) {
            localStorage.setItem(this.tokenKey, res.token);
            this._auth$.next(true);
          }
        })
      );
  }

  logout(): void {
    if (this.isBrowser()) localStorage.removeItem(this.tokenKey);
    this._auth$.next(false);
  }

  getToken(): string | null {
    if (!this.isBrowser()) return null;
    return localStorage.getItem(this.tokenKey);
  }

  getDecodedToken(): any | null {
    const token = this.getToken();
    if (!token) return null;
    try {
      const payload = token.split('.')[1];
      return JSON.parse(atob(payload));
    } catch {
      return null;
    }
  }

  getUserRole(): string | null {
    const decoded = this.getDecodedToken();
    return decoded?.['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ?? null;
  }

  getEmail(): string | null {
    const decoded = this.getDecodedToken();
    return decoded?.['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] ?? null;
  }

  isLoggedIn(): boolean {
    return this._auth$.value;
  }

  authChanges(): Observable<boolean> {
    return this._auth$.asObservable();
  }
}
