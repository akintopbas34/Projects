/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DemandForecastingService } from './demandForecasting.service';

describe('Service: DemandForecasting', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DemandForecastingService]
    });
  });

  it('should ...', inject([DemandForecastingService], (service: DemandForecastingService) => {
    expect(service).toBeTruthy();
  }));
});
