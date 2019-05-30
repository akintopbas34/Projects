/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CompanyMaterialService } from './companyMaterial.service';

describe('Service: CompanyMaterial', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CompanyMaterialService]
    });
  });

  it('should ...', inject([CompanyMaterialService], (service: CompanyMaterialService) => {
    expect(service).toBeTruthy();
  }));
});
