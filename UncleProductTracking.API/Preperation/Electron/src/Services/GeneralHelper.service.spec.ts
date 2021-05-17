/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GeneralHelperService } from './GeneralHelper.service';

describe('Service: GeneralHelper', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GeneralHelperService]
    });
  });

  it('should ...', inject([GeneralHelperService], (service: GeneralHelperService) => {
    expect(service).toBeTruthy();
  }));
});
