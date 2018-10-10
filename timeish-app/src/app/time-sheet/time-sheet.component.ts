import { Component, OnInit, Input } from '@angular/core';
import { TimeSheet } from '../models/time-sheet';
import { Activity } from '../models/activity';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-time-sheet',
  templateUrl: './time-sheet.component.html',
  styleUrls: ['./time-sheet.component.css']
})
export class TimeSheetComponent implements OnInit {

  inEditMode: boolean;
  submitted: boolean;
  timeSheet: TimeSheet;

  constructor(
    private route: ActivatedRoute,
    private apiService: ApiService,
  ) { }

  ngOnInit() {
    this.inEditMode = false;
    this.submitted = false; // TODO: Get this from the database
    this.getTimeSheet();
  }
  
  getTimeSheet(): void {
    // the (+) operator converts string to number
    const id: number = +this.route.snapshot.paramMap.get('id');
    this.apiService
        .getTimeSheet(id)
        .subscribe(t => this.timeSheet = new TimeSheet(t));
  }

  addActivity() {
    this.inEditMode = true;
    this.timeSheet.activities.push(new Activity(this.timeSheet.payPeriodId));
  }

  removeActivity() { }

  save() {
    this.inEditMode = false;
  }

  submit() {
    this.submitted = true;
  }
}