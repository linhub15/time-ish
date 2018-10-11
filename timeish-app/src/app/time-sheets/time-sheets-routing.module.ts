import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimeSheetListComponent } from './time-sheet-list/time-sheet-list.component';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';

const timeSheetsRoutes: Routes = [
  { path: 'timesheets', component: TimeSheetListComponent },
  { path: 'timesheets/:id', component: TimeSheetComponent }
]

@NgModule({
  imports: [ RouterModule.forChild(timeSheetsRoutes) ],
  exports: [ RouterModule ]
})
export class TimeSheetsRoutingModule { }
