import { Component } from '@angular/core';
import { TimeSheet } from './models/time-sheet';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'timeish-app';
  staticTimeSheet: TimeSheet;
  ngOnInit() {
    // Test data for template render
    this.staticTimeSheet = {
      id: 1,
      employeeName: "Alice J",
      activities: [],
      issued: new Date(),
      payPeriodId: 1,
      submitted: null,
      approved: null,
      payPeriod: null
    }
  }
}
