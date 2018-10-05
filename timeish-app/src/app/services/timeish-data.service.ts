import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

import { TimeSheet } from '../models/time-sheet';

@Injectable({
  providedIn: 'root'
})
export class TimeishDataService {
  
  protected timeSheetUrl: string;
  // Business Logic service for the app
  constructor(private http: HttpClient, url: string) {
    // TODO: construct these URLs so automatic check for prod/dev
    //      Maybe there's a base URL somewhere to use
    this.timeSheetUrl = url ? url : 'https://localhost:5001/api/timesheets/';
  }
  
  // No Idea what i'm doing here
  // Possibly add methods to call API and use them from each component

  // GET /api/timesheets
  getTimeSheets(): Observable<TimeSheet[]> {
    return this.http.get<TimeSheet[]>(this.timeSheetUrl);
  }

  // GET /api/timesheets/{id}
  getTimeSheet(id: number): Observable<TimeSheet> {
    return this.http.get<TimeSheet>(this.timeSheetUrl.concat(id.toString()));
  }

  // POST
  postTimeSheet(timeSheet: TimeSheet): Observable<TimeSheet> {
    // How to do error catching?
    return this.http.post<TimeSheet>(this.timeSheetUrl, timeSheet);
  }

  // PUT
  putTimeSheet(timeSheet: TimeSheet): Observable<TimeSheet> {
    return this.http.put<TimeSheet>(this.timeSheetUrl.concat(timeSheet.id.toString()), timeSheet);
  }

  // DELETE
  deleteTimeSheet(timeSheetId: number): Observable<object> {
    return this.http.delete(this.timeSheetUrl.concat(timeSheetId.toString()));
  }
}
