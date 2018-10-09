import { Component, OnInit, Input } from '@angular/core';
import { TimeSheet } from '../models/time-sheet';

@Component({
  selector: 'app-time-sheet-list-item',
  templateUrl: './time-sheet-list-item.component.html',
  styleUrls: ['./time-sheet-list-item.component.css']
})
export class TimeSheetListItemComponent implements OnInit {

  totalAmount: number;
  status: string;

  @Input() timeSheet: TimeSheet;
  constructor() { }

  ngOnInit() {
    this.totalAmount = 35.00;
    this.status = "submitted";
  }

  name(): string {
    return this.timeSheet.employeeName;
  }

}
