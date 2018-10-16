import { Component, OnInit, Inject } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-employee-dialog',
  templateUrl: './add-employee-dialog.component.html',
  styleUrls: ['./add-employee-dialog.component.css']
})

export class AddEmployeeDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AddEmployeeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public employee: Employee) { }


  ngOnInit() {
  }
  
  addNewEmployee() {
    this.dialogRef.close(this.employee);
  }
}
