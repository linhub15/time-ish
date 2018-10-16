import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from '../employee.service';
import { Observable, of } from 'rxjs';
import { AddEmployeeDialogComponent } from '../add-employee-dialog/add-employee-dialog.component';
import { MatDialog } from '@angular/material';
import { map, flatMap } from 'rxjs/operators';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  employees: Employee[];
  constructor(private employeeService:EmployeeService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.employeeService.getEmployees()
        .subscribe(array => this.employees = array);
  }

  openDialog(): void {
    const employee = new Employee();
    const dialogRef = this.dialog.open(AddEmployeeDialogComponent, {
      autoFocus: false,
      data: employee
    });

    dialogRef.afterClosed().subscribe(employee => {
      if (!employee) { return }
      this.employeeService.add(employee)
        .subscribe(e => this.employees.push(e))
    })
  }
}
