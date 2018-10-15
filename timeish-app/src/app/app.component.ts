import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild('sidenav') sidenav: MatSidenav;

  links: Link[] = [];

  ngOnInit() { 
    this.links.push(new Link('/timesheets', 'Time Sheets'));
    this.links.push(new Link('/employees', 'Employees'));
  }

  toggleSideNav(toggled: boolean) {
    if (!toggled) { return }
    this.sidenav.toggle();
  }
  closeSideNav() {
    this.sidenav.close();
  }
}

export class Link {
  constructor(
    public url: string, 
    public text: string)
    {}
}