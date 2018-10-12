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

  deleteActivity(activityId: number) {
    // Removes the activity component from the view
    let index = this.timeSheet.activities
        .findIndex(activity => activity.id == activityId)
    this.timeSheet.activities.splice(index, 1);

    // "Add Activity" doesn't insert new Activity in DB
    // Can't delete what doesn't exist
    if (!activityId) { return } 
    this.apiService.deleteActivity(activityId).subscribe();
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