import { TestBed } from '@angular/core/testing';

import { TimeishDataService } from './timeish-data.service';

describe('TimeishDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TimeishDataService = TestBed.get(TimeishDataService);
    expect(service).toBeTruthy();
  });
});
