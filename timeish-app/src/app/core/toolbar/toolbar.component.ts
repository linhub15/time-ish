import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {
  title: string;
  constructor() { }

  @Output() toggleSidenav = new EventEmitter<boolean>();

  ngOnInit() {
  }

  sidenavToggled() {
    this.toggleSidenav.emit(true);
  }
  
}
