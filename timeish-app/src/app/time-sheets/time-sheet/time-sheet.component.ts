import { Component, OnInit, Input } from '@angular/core';
import { TimeSheet } from '../../models/time-sheet.model';
import { ActivatedRoute } from '@angular/router';
import { TimeSheetsService } from '../time-sheets.service';

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
    private apiService: TimeSheetsService,
  ) { }

  ngOnInit() {
    this.inEditMode = false;
    this.submitted = false; // TODO: Get this from the database
    this.getTimeSheet();
  }
  
  getTimeSheet(): void {
    // the (+) operator converts string to number
    const id: number = +this.route.snapshot.paramMap.get('id');
    this.apiService.getTimeSheet(id)
        .subscribe(timeSheet => {
          this.timeSheet = new TimeSheet().deserialize(timeSheet);
        });
  }

  addActivity() {
    this.inEditMode = true;
    this.timeSheet.addActivity();
  }

  removeActivity() {
    this.timeSheet.activities.pop();
    //this.save();
  }

  save() {
    this.inEditMode = false;
    this.apiService.putTimeSheet(this.timeSheet)
        .subscribe(timeSheet => {
          this.timeSheet.deserialize(timeSheet);
        });
  }

  submit() {
    // Are you sure you want to submit? No more changes can be made
    this.submitted = true;
    this.timeSheet.submitted = new Date();
    this.apiService.putTimeSheet(this.timeSheet);
  }
}