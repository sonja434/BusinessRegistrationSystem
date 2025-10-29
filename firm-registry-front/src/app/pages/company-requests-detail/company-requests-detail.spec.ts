import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyRequestsDetail } from './company-requests-detail';

describe('CompanyRequestsDetail', () => {
  let component: CompanyRequestsDetail;
  let fixture: ComponentFixture<CompanyRequestsDetail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyRequestsDetail]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyRequestsDetail);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
