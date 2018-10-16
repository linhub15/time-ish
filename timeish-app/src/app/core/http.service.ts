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

  list<T extends Deserializable>(resource: string, model: new () => T)
      : Observable<Array<T>> {
    return this.http.get<Array<T>>(this.baseUrl.concat(resource))
      .pipe(
        map(array => {
          let newArray = [];
          array.forEach(item => 
            newArray.push(new model().deserialize(item)));
          return newArray;
        })
      );
  }

  add<T extends Deserializable>(resource: string, newObject, model: new () => T)
      : Observable<T> {
    return this.http.post(this.baseUrl.concat(resource), newObject)
        .pipe(map(obj => {return new model().deserialize(obj)}));
  }
}