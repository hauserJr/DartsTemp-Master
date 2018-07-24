import { Injectable } from '@angular/core';
import { AngularTempDataModel } from './AngularTempDataModel';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})

export class MessageService {
  private messageUrl = 'http://localhost:1974/api/Messages';

  constructor(private http: HttpClient) { }
  getMsgs(): Observable<AngularTempDataModel[]> {
    return this.http.get<AngularTempDataModel[]>(this.messageUrl).pipe(
      catchError(this.handleError<AngularTempDataModel[]>('getMessage'))
    );
  }


  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
