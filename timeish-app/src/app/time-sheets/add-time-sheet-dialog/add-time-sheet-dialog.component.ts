import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Employee } from 'src/app/models/employee.model';
import { TimeSheet } from 'src/app/models/time-sheet.model';
import { Observable } from 'rxjs';


/**
 * All objects must be deserialized
 * Functions need to be called from within DialogComponent
 */
export interface DialogData {
  employees$: Observable<Employee[]>;
}

@Component({
  selector: 'app-add-time-sheet-dialog',
  templateUrl: './add-time-sheet-dialog.component.html',
  styleUrls: ['./add-time-sheet-dialog.component.css']
})
export class AddTimeSheetDialogComponent implements OnInit{

  selectedEmployee: Employee;

  constructor( 
    public dialogRef: MatDialogRef<AddTimeSheetDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  ngOnInit() {}

  addNewTimeSheet() {
    if (!this.selectedEmployee) { return }
    let timeSheet = new TimeSheet();
    timeSheet.employeeId = this.selectedEmployee.id;
    this.dialogRef.close(timeSheet);      // Pass the timeSheet as result
  }

  displayFullName(employee: Employee): string {
    return employee ? employee.fullName() : '';
  }
}
