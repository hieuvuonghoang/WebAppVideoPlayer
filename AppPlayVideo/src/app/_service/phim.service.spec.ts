import { TestBed } from '@angular/core/testing';

import { PhimService } from './phim.service';

describe('PhimService', () => {
  let service: PhimService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PhimService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
