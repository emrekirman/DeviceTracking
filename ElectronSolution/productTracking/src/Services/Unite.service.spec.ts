/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UniteService } from './Unite.service';

describe('Service: Unite', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UniteService]
    });
  });

  it('should ...', inject([UniteService], (service: UniteService) => {
    expect(service).toBeTruthy();
  }));
});
