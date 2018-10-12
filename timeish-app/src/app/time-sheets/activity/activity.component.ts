import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Activity } from '../../models/activity.model';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {

  @Input() activity: Activity;
  @Output() deleteActivity = new EventEmitter<number>();

  constructor() { }

  ngOnInit() { }

  calculatePay(): void {
    this.activity.pay = 25 * this.activity.hours;
  }

  delete(): void {
    this.deleteActivity.emit(this.activity.id);
  }
}
