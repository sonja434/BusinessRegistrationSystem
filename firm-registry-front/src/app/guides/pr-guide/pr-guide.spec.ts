import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrGuide } from './pr-guide';

describe('PrGuide', () => {
  let component: PrGuide;
  let fixture: ComponentFixture<PrGuide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PrGuide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrGuide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
