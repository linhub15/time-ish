import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { TimeSheetListComponent } from './time-sheet-list/time-sheet-list.component';


const routes: Routes = [
  { path: '', redirectTo: '/timesheets', pathMatch: 'full' },
  { path: 'timesheets', component: TimeSheetListComponent },
  { path: 'timesheets/:id', component: TimeSheetComponent }
]
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
