import { Component, OnInit, Inject } from '@angular/core';
import { TimeSheet } from 'src/app/models/time-sheet.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';


export interface ReviewDialogData {
  approved: boolean;
  deleted: boolean;
  rejected: boolean;
  timeSheet: TimeSheet;
  
}

@Component({
  selector: 'app-review-time-sheet-dialog',
  templateUrl: './review-time-sheet-dialog.component.html',
  styleUrls: ['./review-time-sheet-dialog.component.css']
})
export class ReviewTimeSheetDialogComponent implements OnInit {
  displayedColumns: string[] = ['date', 'description', 'hours', 'pay'];
  constructor(public dialogRef: MatDialogRef<ReviewTimeSheetDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ReviewDialogData) { }

  ngOnInit() {}

  approve() {
    this.data.approved = true;
    this.data.timeSheet.approved = new Date();
    this.dialogRef.close(this.data);
  }

  reject() {
    this.data.rejected = true;
    this.dialogRef.close(this.data);
  }

  delete() {
    this.data.deleted = true;
    this.dialogRef.close(this.data);
  }
}
