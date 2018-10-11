import { Component, OnInit, Input } from '@angular/core';
import { TimeSheet } from '../models/time-sheet.model';
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
    this.apiService.getTimeSheet(id)
        .subscribe(timeSheet => {
          this.timeSheet = new TimeSheet().deserialize(timeSheet);
        });
  }

  addActivity() {
    this.inEditMode = true;
    this.timeSheet.addActivity();
  }

  removeActivity() { }

  save() {
    this.inEditMode = false;
  }

  submit() {
    this.submitted = true;
  }
}