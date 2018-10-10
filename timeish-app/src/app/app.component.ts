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
    this.staticTimeSheet = new TimeSheet();
    this.staticTimeSheet.id=1;
    this.staticTimeSheet.employeeName="Alice J",
    this.staticTimeSheet.activities=[],
    this.staticTimeSheet.issued=new Date();
    this.staticTimeSheet.payPeriodId=1;
  }
}