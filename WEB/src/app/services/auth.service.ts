import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

export interface User {
  firstName:  string;
  middleName?: string;
  lastName:   string;
  username:   string;
  email:      string;
  password:   string;
  age:        number;
  role:      string;
}

export interface RegisterForm {
  firstName:  string;
  middleName?: string;
  lastName:   string;
  username:   string;
  email:      string;
  password:   string;
  age:        number;
  role?:      string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5230/api/users';
  private userSubject = new BehaviorSubject<User | null>(null);
  user$ = this.userSubject.asObservable();

  constructor(private http: HttpClient) {
    const userJson = localStorage.getItem('currentUser');
    if (userJson) {
      this.userSubject.next(JSON.parse(userJson));
    }
  }

  login(username: string, password: string): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/login`, { username, password }).pipe(
      tap(user => {
        this.userSubject.next(user);
        localStorage.setItem('currentUser', JSON.stringify(user));  // <-- add this
      })
    );
  }

  register(data: RegisterForm): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, data);
  }

  logout(): void {
    localStorage.removeItem('currentUser');
    this.userSubject.next(null);
  }

  get currentUser(): User | null {
    return this.userSubject.value;
  }

  isLoggedIn(): boolean {
    return this.currentUser !== null;
  }

  getCurrentUser() {
    return JSON.parse(localStorage.getItem('currentUser') || 'null');
  }
}
