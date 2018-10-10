import { Component } from '@angular/core';
import { TimeSheet } from './models/time-sheet';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'timeish-app';
  ngOnInit() { }
}