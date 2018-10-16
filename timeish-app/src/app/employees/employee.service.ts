import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable, of, from } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../core/http.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly endPoint: string = 'employees/'

  constructor(private http: HttpClient,
    private api: HttpService) { }

  getEmployees(): Observable<Employee[]> {
    return this.api.list<Employee>(this.endPoint, Employee);
  }

  add(employee: Employee): Observable<any> {
    return this.api.add(this.endPoint, employee);
  }
}
