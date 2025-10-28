import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DooGuide } from './doo-guide';

describe('DooGuide', () => {
  let component: DooGuide;
  let fixture: ComponentFixture<DooGuide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DooGuide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DooGuide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
