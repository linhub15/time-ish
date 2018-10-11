import { Component, OnInit, Input } from '@angular/core';
import { Activity } from '../models/activity.model';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {

  @Input() activity: Activity;
  constructor() { }

  ngOnInit() {

  }
  calculatePay(): void {
    this.activity.pay = 25 * this.activity.hours;
  }
}
