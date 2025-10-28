import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KdGuide } from './kd-guide';

describe('KdGuide', () => {
  let component: KdGuide;
  let fixture: ComponentFixture<KdGuide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KdGuide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KdGuide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
