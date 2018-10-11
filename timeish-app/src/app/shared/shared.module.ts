import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { MaterialComponentsModule } from './material-components.module';

@NgModule({
  imports: [ CommonModule,
             FormsModule, MaterialComponentsModule ],
  declarations: [],
  exports: [
    FormsModule,
    MaterialComponentsModule
  ]
})
export class SharedModule { }
