/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MaterialStockService } from './materialStock.service';

describe('Service: MaterialStock', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MaterialStockService]
    });
  });

  it('should ...', inject([MaterialStockService], (service: MaterialStockService) => {
    expect(service).toBeTruthy();
  }));
});
