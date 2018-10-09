import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { TimeSheetListComponent } from './time-sheet-list/time-sheet-list.component';
import { HttpClientModule } from '@angular/common/http';
import { TimeSheetListItemComponent } from './time-sheet-list-item/time-sheet-list-item.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCardModule} from '@angular/material';


@NgModule({
  declarations: [
    AppComponent,
    TimeSheetListComponent,
    TimeSheetListItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
