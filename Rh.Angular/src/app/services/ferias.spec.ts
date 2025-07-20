import { TestBed } from '@angular/core/testing';

import { Ferias } from './ferias';

describe('Ferias', () => {
  let service: Ferias;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Ferias);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
