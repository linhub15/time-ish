import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

import { TimeSheetListComponent } from './time-sheet-list/time-sheet-list.component';
import { TimeSheetListItemComponent } from './time-sheet-list-item/time-sheet-list-item.component';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { ActivityComponent } from './activity/activity.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule,
  MatCardModule, 
  MatFormFieldModule, 
  MatInputModule, 
  MatDatepickerModule, 
  MatExpansionModule,
  MatNativeDateModule} from '@angular/material';



@NgModule({
  declarations: [
    AppComponent,
    TimeSheetListComponent,
    TimeSheetListItemComponent,
    TimeSheetComponent,
    ActivityComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule, 
    MatFormFieldModule, 
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatExpansionModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
