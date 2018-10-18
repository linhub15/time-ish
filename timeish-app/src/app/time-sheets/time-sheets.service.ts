import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { TimeSheet } from '../models/time-sheet.model';
import { HttpService } from '../core/http.service';

@Injectable({
  providedIn: 'root'
})
export class TimeSheetsService {
  
  readonly _apiUrl: string;
  readonly _timeSheetUrl: string;
  readonly _activityUrl: string;
  readonly type = TimeSheet;    // could be injected 
  readonly resource: string = 'timesheets';  // could be injected

  constructor(private http: HttpClient,
    private httpService: HttpService) {
    this._apiUrl = 'https://localhost:5001/api/'
    this._timeSheetUrl = this._apiUrl + 'timesheets/';
    this._activityUrl = this._timeSheetUrl + 'activities/'
  }
  

  // GET /api/timesheets
  getTimeSheets(): Observable<TimeSheet[]> {
    return this.httpService.list(this.resource, TimeSheet);
  }

  // GET /api/timesheets/{id}
  getTimeSheet(id: number): Observable<TimeSheet> {
    return this.httpService.get<TimeSheet>(this.resource, id, TimeSheet);
  }

  // POST
  postTimeSheet(timeSheet: TimeSheet): Observable<TimeSheet> {
    return this.httpService.add(this.resource, timeSheet, TimeSheet);
  }

  // PUT
  update(timeSheet: TimeSheet): Observable<TimeSheet> {
    return this.httpService.update(this.resource, timeSheet, TimeSheet);
  }

  // DELETE
  deleteTimeSheet(timeSheetId: number): void {
    this.http.delete(this._timeSheetUrl.concat(timeSheetId.toString()))
        .subscribe();
  }

  // DELETE
  deleteActivity(activityId: number): Observable<object> {
    return this.http.delete(this._activityUrl.concat(activityId.toString()));
  }
}
