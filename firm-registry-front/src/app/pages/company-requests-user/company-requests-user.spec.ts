import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyRequestsUser } from './company-requests-user';

describe('CompanyRequestsUser', () => {
  let component: CompanyRequestsUser;
  let fixture: ComponentFixture<CompanyRequestsUser>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyRequestsUser]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompanyRequestsUser);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
