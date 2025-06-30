import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface JobOffer {
  id?: number;
  title: string;
  description: string;
  location: string;
  createdBy: string;
  createdOn?: string;
}

@Injectable({ providedIn: 'root' })
export class JobService {
  private apiUrl = 'http://localhost:5230/api/joboffers';

  constructor(private http: HttpClient) {}

  getAll(): Observable<JobOffer[]> {
    return this.http.get<JobOffer[]>(this.apiUrl);
  }

  create(offer: JobOffer): Observable<JobOffer> {
    return this.http.post<JobOffer>(this.apiUrl, offer);
  }

  applyToJob(userId: number, jobOfferId: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/apply`, { userId, jobOfferId });
  }
}
