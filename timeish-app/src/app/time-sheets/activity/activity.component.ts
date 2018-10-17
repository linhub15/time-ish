import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { Activity } from '../../models/activity.model';
import { MatExpansionPanel } from '@angular/material';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent {

  @Input() activity: Activity;
  @Output() deleteActivity = new EventEmitter<number>();
  @Output() addActivity = new EventEmitter<true>();

  @ViewChild('accordian') accordian: MatExpansionPanel;

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
    this.accordian.close();
  }
}
