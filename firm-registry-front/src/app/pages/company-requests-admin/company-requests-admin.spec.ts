import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyRequestsAdmin } from './company-requests-admin';

describe('CompanyRequestsAdmin', () => {
  let component: CompanyRequestsAdmin;
  let fixture: ComponentFixture<CompanyRequestsAdmin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyRequestsAdmin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyRequestsAdmin);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
