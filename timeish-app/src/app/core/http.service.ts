import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Deserializable } from "../models/deserializable.model";


@Injectable({
  providedIn: 'root'
})
export class HttpService implements OnInit {

  readonly baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  ngOnInit() { }

  list<T extends Deserializable>(resource: string, c: new () => T)
      : Observable<Array<T>> {
    let obj: Deserializable;
    return this.http.get<Array<T>>(this.baseUrl.concat(resource))
      .pipe(
        map(array => {
          let newArray = [];
          array.forEach(item => 
            newArray.push(new c().deserialize(item)));
          return newArray;
        })
      );
  }

  add<T>(resource: string, newObject: T): Observable<any> {
    return this.http.post(this.baseUrl.concat(resource), newObject);
  }
}