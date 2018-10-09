import { Component, OnInit, Input } from '@angular/core';
import { TimeSheet } from '../models/time-sheet';
import { Activity } from '../models/activity';

@Component({
  selector: 'app-time-sheet',
  templateUrl: './time-sheet.component.html',
  styleUrls: ['./time-sheet.component.css']
})
export class TimeSheetComponent implements OnInit {

  inEditMode: boolean;
  submitted: boolean;
  activities: Activity[] = [];
  @Input() timeSheet: TimeSheet;

  constructor() { }

  ngOnInit() {
    this.inEditMode = false;
    this.submitted = false; // TODO: Get this from the database
    // TODO: activities should be populated from database
  }

  addActivity() {
    this.inEditMode = true;
    this.activities.push(new Activity(this.timeSheet.payPeriodId));
  }
  removeActivity() { }
  save() {
    this.inEditMode = false;
  }
  submit() {
    this.submitted = true;
  }
}