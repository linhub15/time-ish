import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';

import { TimeSheet } from '../../models/time-sheet.model';

import { TimeSheetsService } from '../time-sheets.service';
import { EmployeeService } from 'src/app/employees/employee.service';

import { AddTimeSheetDialogComponent } from '../add-time-sheet-dialog/add-time-sheet-dialog.component';

@Component({
  selector: 'app-time-sheet-list',
  templateUrl: './time-sheet-list.component.html',
  styleUrls: ['./time-sheet-list.component.css']
})
export class TimeSheetListComponent implements OnInit {

  timeSheets: TimeSheet[] = [];
  
  constructor(private apiService:TimeSheetsService,
      private employeeService: EmployeeService,
      public dialog: MatDialog) { }

  ngOnInit() {
    this.apiService.getTimeSheets()
        .subscribe(array => this.timeSheets = array);
  }

  deleteTimeSheet(timeSheet: TimeSheet): void {
    const id = this.timeSheets.indexOf(timeSheet);
    this.timeSheets.splice(id, 1);
    this.apiService.deleteTimeSheet(timeSheet.id);
  }

  openDialog(): void {
    const employees$ = this.employeeService.getEmployees();
    const dialogRef = this.dialog.open(AddTimeSheetDialogComponent, {
      autoFocus: false,
      data: {employees$: employees$}
    });

    dialogRef.afterClosed().subscribe(timeSheet => {
      if (!timeSheet) { return }
      this.apiService.postTimeSheet(timeSheet)
          .subscribe(sheet => {
            sheet = new TimeSheet().deserialize(sheet);
            this.timeSheets.push(sheet);
          });
    })
  }
}