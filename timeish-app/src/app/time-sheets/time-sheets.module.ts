import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

/* Components */
import { TimeSheetListComponent } from './time-sheet-list/time-sheet-list.component';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { ActivityComponent } from './activity/activity.component';
import { TimeSheetsRoutingModule } from './time-sheets-routing.module';

@NgModule({
  imports: [ CommonModule, SharedModule, TimeSheetsRoutingModule ],
  declarations: [
    TimeSheetListComponent,
    TimeSheetComponent,
    ActivityComponent
  ]
})
export class TimeSheetsModule { }
