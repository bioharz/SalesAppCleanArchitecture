import { TestBed } from '@angular/core/testing';

import { StaticsService } from './statics.service';

describe('StaticsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StaticsService = TestBed.get(StaticsService);
    expect(service).toBeTruthy();
  });
});
