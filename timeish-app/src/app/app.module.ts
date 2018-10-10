import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';;

// TODO: Group similar components into modules
import { AppComponent } from './app.component';
import { TimeSheetListComponent } from './time-sheet-list/time-sheet-list.component';
import { TimeSheetListItemComponent } from './time-sheet-list-item/time-sheet-list-item.component';
import { TimeSheetComponent } from './time-sheet/time-sheet.component';
import { ActivityComponent } from './activity/activity.component';

import { MaterialComponentsModule } from './material-components.module';

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
    AppRoutingModule,
    MaterialComponentsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
