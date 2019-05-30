/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProductInformationService } from './productInformation.service';

describe('Service: ProductInformation', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductInformationService]
    });
  });

  it('should ...', inject([ProductInformationService], (service: ProductInformationService) => {
    expect(service).toBeTruthy();
  }));
});
