import { Injectable, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Deserializable } from "../models/deserializable.model";


@Injectable({
  providedIn: 'root'
})
export class HttpService implements OnInit {

  // This will be passed in from variables...
  readonly baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  ngOnInit() { }

  list<T extends Deserializable>(resource: string, model: new () => T)
      : Observable<Array<T>> {
    return this.http.get<Array<T>>(this.buildUrl(resource))
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
    return this.http.post(this.buildUrl(resource), newObject)
        .pipe(map(obj => {return new model().deserialize(obj)}));
  }

  delete(resource: string, id: number): Observable<any> {
    if (!resource || !id) { console.log("required params"); return; }
    return this.http.delete(this.buildUrl(resource, id.toString()));
  }
  private buildUrl(...resource: string[]): string {
    let buff: string = this.baseUrl;
    resource.forEach(item => buff = buff.concat(item + '/'));
    return buff;
  }
}