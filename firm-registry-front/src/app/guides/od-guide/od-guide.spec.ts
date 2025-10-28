import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OdGuide } from './od-guide';

describe('OdGuide', () => {
  let component: OdGuide;
  let fixture: ComponentFixture<OdGuide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OdGuide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OdGuide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
