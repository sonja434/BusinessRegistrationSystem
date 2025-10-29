import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyRequestReview } from './company-request-review';

describe('CompanyRequestReview', () => {
  let component: CompanyRequestReview;
  let fixture: ComponentFixture<CompanyRequestReview>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyRequestReview]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyRequestReview);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
