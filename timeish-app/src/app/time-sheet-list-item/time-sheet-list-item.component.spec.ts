import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeSheetListItemComponent } from './time-sheet-list-item.component';

describe('TimeSheetListItemComponent', () => {
  let component: TimeSheetListItemComponent;
  let fixture: ComponentFixture<TimeSheetListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimeSheetListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeSheetListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
