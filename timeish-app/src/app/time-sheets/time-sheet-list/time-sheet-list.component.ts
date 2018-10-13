import { Component, OnInit, Inject } from '@angular/core';
import { TimeSheetsService } from '../time-sheets.service';
import { TimeSheet } from '../../models/time-sheet.model';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Employee } from 'src/app/models/employee.model';
import { AddTimeSheetDialogComponent } from '../add-time-sheet-dialog/add-time-sheet-dialog.component';
import { EmployeeService } from 'src/app/employee.service';

@Component({
  selector: 'app-time-sheet-list',
  templateUrl: './time-sheet-list.component.html',
  styleUrls: ['./time-sheet-list.component.css']
})
export class TimeSheetListComponent implements OnInit {

  timeSheets: TimeSheet[];
  
  constructor(private apiService:TimeSheetsService,
      private employeeService: EmployeeService,
      public dialog: MatDialog) { }

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
  deleteTimeSheet(timeSheet: TimeSheet): void {
    const id = this.timeSheets.indexOf(timeSheet);
    this.timeSheets.splice(id, 1);
    this.apiService.deleteTimeSheet(timeSheet.id);
  }

  openDialog(): void {
    const employees: Employee[] = [];
    this.employeeService.getEmployees().subscribe(array => {
      for (const employee of array) {
        employees.push(new Employee().deserialize(employee));
      }
    });
    const dialogRef = this.dialog.open(AddTimeSheetDialogComponent, {
      autoFocus: false,
      data: {employees: employees}
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