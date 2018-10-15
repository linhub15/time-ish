import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from '../employee.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees$: Observable<Employee[]>;
  constructor(private apiService:EmployeeService) { }

  ngOnInit() {
    this.employees$ = this.apiService.getEmployees();
  }

}
