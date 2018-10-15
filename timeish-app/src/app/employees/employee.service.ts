import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Observable, of, from } from 'rxjs';
import { map, mapTo } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { mapToExpression } from '@angular/compiler/src/render3/view/util';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly resourceUrl: string = 'https://localhost:5001/api/employees/'

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.resourceUrl)
        .pipe(map(employees => {
          let newList: Employee[] = [];
          for (let employee of employees) {
            newList.push(new Employee().deserialize(employee));
          }
          return newList;
        }))
  }
}
