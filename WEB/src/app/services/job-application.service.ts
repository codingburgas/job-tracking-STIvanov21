import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface ApplyJobRequest {
  userId: number;
  jobOfferId: number;
}

@Injectable({
  providedIn: 'root',
})
export class JobApplicationService {
  private apiUrl = '/api/Applications';

  constructor(private http: HttpClient) {}

  applyToJob(userId: number, jobOfferId: number): Observable<any> {
    const payload: ApplyJobRequest = { userId, jobOfferId };
    return this.http.post(`${this.apiUrl}/apply`, payload);
  }
}
