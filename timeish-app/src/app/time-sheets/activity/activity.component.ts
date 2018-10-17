import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Activity } from '../../models/activity.model';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css'],
  providers: [
  ],
})
export class ActivityComponent {
  @Input() activity: Activity;
  @Output() deleteActivity = new EventEmitter<number>();
  @Output() addActivity = new EventEmitter<true>();

  constructor() { }


  calculatePay(): void {
    //TODO: remove hard coded pay
    this.activity.pay = 25 * this.activity.hours;
  }

  delete(): void {
    this.deleteActivity.emit(this.activity.id);
  }

  add(): void {
    this.addActivity.emit(true);
  }
}
