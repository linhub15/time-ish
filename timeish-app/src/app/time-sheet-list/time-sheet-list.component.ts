import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { TimeSheet } from '../models/time-sheet.model';

@Component({
  selector: 'app-time-sheet-list',
  templateUrl: './time-sheet-list.component.html',
  styleUrls: ['./time-sheet-list.component.css'],
  providers: [ApiService]
})
export class TimeSheetListComponent implements OnInit {

  timeSheets: TimeSheet[];
  
  constructor(private apiService:ApiService) { }

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
