import { NgModule } from '@angular/core';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import {MatButtonModule, MatCardModule, 
        MatFormFieldModule, MatInputModule, 
        MatDatepickerModule, MatExpansionModule,
        MatNativeDateModule, MatDialogModule,
        MatAutocompleteModule, MatIconModule,
        MatToolbarModule, MatSidenavModule,
      } from '@angular/material';

  const materialComponentModules = [
    BrowserAnimationsModule, MatButtonModule, MatCardModule,
    MatFormFieldModule, MatInputModule, MatDatepickerModule,
    MatNativeDateModule, MatExpansionModule, MatDialogModule,
    MatAutocompleteModule, MatIconModule, MatToolbarModule,
    MatSidenavModule,
  ];

@NgModule({
  imports: materialComponentModules,
  exports: materialComponentModules,
})
export class MaterialComponentsModule { }
