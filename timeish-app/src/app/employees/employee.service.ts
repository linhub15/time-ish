import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable, of, from } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HttpService } from '../core/http.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly resourceUrl: string = 'https://localhost:5001/api/employees/'

  constructor(private http: HttpClient,
    private api: HttpService) { }

  getEmployees(): Observable<Employee[]> {
    return this.api.list<Employee>('employees/', Employee);
  }

  postEmployee(employee: Employee): Observable<any> {
    return this.api.add('employees/', employee);
  }
}
