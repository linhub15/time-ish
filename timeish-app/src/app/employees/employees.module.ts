import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { EmployeesRoutingModule } from './employees-routing.module';

/* Components */
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { EmployeeDetailComponent } from './employee-detail/employee-detail.component';
import { AddEmployeeDialogComponent } from './add-employee-dialog/add-employee-dialog.component';

@NgModule({
  imports: [ CommonModule, SharedModule, EmployeesRoutingModule ],
  entryComponents: [],
  declarations: [EmployeesListComponent, EmployeeDetailComponent, AddEmployeeDialogComponent]
})
export class EmployeesModule { }
