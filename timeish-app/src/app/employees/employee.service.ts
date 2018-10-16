import { Injectable, OnInit } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable, of, from } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../core/http.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService implements OnInit {

  readonly endPoint: string = 'employees/'

  constructor(private api: HttpService) { }
  ngOnInit() {}
  getEmployees(): Observable<Employee[]> {
    return this.api.list<Employee>(this.endPoint, Employee);
  }

  add(employee: Employee): Observable<Employee> {
    return this.api.add(this.endPoint, employee, Employee);
  }

  delete(id: number): Observable<any> {
    return this.api.delete(this.endPoint, id);
  }
}
