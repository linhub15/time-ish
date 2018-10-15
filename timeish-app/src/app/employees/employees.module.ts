import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { EmployeesRoutingModule } from './employees-routing.module';

/* Components */
import { EmployeesComponent } from './employees/employees.component';

@NgModule({
  imports: [ CommonModule, SharedModule, EmployeesRoutingModule ],
  entryComponents: [],
  declarations: [EmployeesComponent]
})
export class EmployeesModule { }
