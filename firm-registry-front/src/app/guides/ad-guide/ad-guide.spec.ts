import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdGuide } from './ad-guide';

describe('AdGuide', () => {
  let component: AdGuide;
  let fixture: ComponentFixture<AdGuide>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdGuide]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdGuide);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
