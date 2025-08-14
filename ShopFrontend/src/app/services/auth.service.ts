import { Injectable, PLATFORM_ID, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private platformId = inject(PLATFORM_ID);
  private apiUrl = 'http://localhost:4201/api/Auth'
  private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public currentUser: Observable<any> = this.currentUserSubject.asObservable();


  constructor() {
       if (isPlatformBrowser(this.platformId)) {
      const savedToken = localStorage.getItem('token');
      if (savedToken) {
        const decodedUser = this.decodeToken(savedToken);
        this.currentUserSubject.next(decodedUser);
      }
    }
  }

  login(credentials: { username: string; password: string }): Observable<any> {
    return this.http
      .post<any>(this.apiUrl + '/login', credentials, {
      })
      .pipe(
        catchError((error) => {
          console.error('Error de login', error);
          throw error;
        })
      );
  }

  saveUserSession(response: any): void {
      if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('token', response.token);
    }
    const decodedToken = this.decodeToken(response.token);
    this.currentUserSubject.next(decodedToken);
  }

  logout(): void {
  if (isPlatformBrowser(this.platformId)) {
      localStorage.removeItem('token');
    }
    this.currentUserSubject.next(null);
  }

  getToken(): string | null {
        if (isPlatformBrowser(this.platformId)) {
      return localStorage.getItem('token');
    }
    return null;
  }

  isLogged(): boolean {
    const currentUser = this.currentUserSubject.value;

  
    if (!currentUser || !currentUser.exp) {
     
      return false; 
    }

    const currentTime = Math.floor(Date.now() / 1000);

   
    if (currentUser.exp <= currentTime) {
      console.log("Token Expirado", currentTime)
      this.logout(); // Si el token ha expirado, cerrar sesión
      return false;
    }

    return true;
  }

  getRoles(): string[] {
    const currentUser = this.currentUserSubject.value;
    return currentUser?.roles ? [currentUser.roles] : [];
  }

  hasRole(role: string): boolean {
    const roles = this.getRoles();
    return roles.includes(role); 
  }


  private decodeToken(token: string): any {
    try {
    
      const payload = token.split('.')[1];
      const decodedPayload = atob(payload);
      return JSON.parse(decodedPayload); 
    } catch (error) {
      console.error('Error al decodificar el token:', error);
      return null;
    }
  }
}
