import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from '../employee.service';
import { Observable } from 'rxjs';
import { AddEmployeeDialogComponent } from '../add-employee-dialog/add-employee-dialog.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  employees$: Observable<Employee[]>;
  constructor(private employeeService:EmployeeService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.employees$ = this.employeeService.getEmployees();
  }

  openDialog(): void {
    const employee = new Employee();
    const dialogRef = this.dialog.open(AddEmployeeDialogComponent, {
      autoFocus: false,
      data: employee
    });

    dialogRef.afterClosed().subscribe(employee => {
      if (!employee) { return }
      console.log(employee);
      this.employeeService.add(employee).subscribe();
      // add employee to list of employees$
    })
  }
}
