import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityCodes } from './activity-codes';

describe('ActivityCodes', () => {
  let component: ActivityCodes;
  let fixture: ComponentFixture<ActivityCodes>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActivityCodes]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActivityCodes);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
