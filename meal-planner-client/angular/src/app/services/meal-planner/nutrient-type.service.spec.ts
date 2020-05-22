import { TestBed } from '@angular/core/testing';

import { NutrientTypeService } from './nutrient-type.service';

describe('NutrientTypeService', () => {
  let service: NutrientTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NutrientTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
