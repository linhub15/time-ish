import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'timeish-app';
  @ViewChild('sidenav') sidenav: MatSidenav;

  ngOnInit() { 
  }

  toggleSideNav(toggled: boolean) {
    if (!toggled) { return }
    this.sidenav.toggle();
  }
  closeSideNav() {
    this.sidenav.close();
  }
}