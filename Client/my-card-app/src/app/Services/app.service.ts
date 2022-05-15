import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private apiUrl: string;
  headers = new HttpHeaders();
  constructor(private httpClient: HttpClient) {
    this.apiUrl = environment.apiUrl+'api/cardSort/';
    this.headers = this.headers.set('Content-Type', 'application/json');
  }

  getSortedCards(cards: string[] | undefined) {
    return this.httpPost('sort', JSON.stringify(cards)).pipe(map(response => {
      console.log(response);
      const body = response;
      return body || {};
    }));
  }

  httpGet(url: string): Observable<any> {
    return this.httpClient.get(this.apiUrl + url).pipe(
      catchError(error => this.handleResponseError(error)),
    );
  }
  httpPost(url: string, data: string): Observable<any> {
    return this.httpClient.post(this.apiUrl + url, data, { headers: this.headers }).pipe(
      catchError(error => this.handleResponseError(error)),
    );
  }

  handleResponseError(error: any): Observable<Response> {
    console.log(error);
    return throwError(() => error);
  }
}