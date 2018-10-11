import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/timesheets', pathMatch: 'full' },
  // {path: 'timesheets', loadChildren: 'app/time-sheets/time-sheets.module#TimeSheetsModule' }
]
@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
