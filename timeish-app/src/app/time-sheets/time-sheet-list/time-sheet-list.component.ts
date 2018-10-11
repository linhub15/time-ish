import { Component, OnInit } from '@angular/core';
import { TimeSheetsService } from '../time-sheets.service';
import { TimeSheet } from '../../models/time-sheet.model';

@Component({
  selector: 'app-time-sheet-list',
  templateUrl: './time-sheet-list.component.html',
  styleUrls: ['./time-sheet-list.component.css']
})
export class TimeSheetListComponent implements OnInit {

  timeSheets: TimeSheet[];
  
  constructor(private apiService:TimeSheetsService) { }

  ngOnInit() {
    this.getTimeSheets();
  }

  getTimeSheets(): void {
    this.timeSheets = [];
    this.apiService.getTimeSheets()
      .subscribe(timeSheets => {
        timeSheets.forEach(sheet => {
          this.timeSheets.push(new TimeSheet().deserialize(sheet))
        })
      });
  }
}
