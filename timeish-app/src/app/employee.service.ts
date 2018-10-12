import { Injectable } from '@angular/core';
import { Employee } from './models/employee.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly resourceUrl: string = 'https://localhost:5001/api/employees/'

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.resourceUrl);
  }
}
