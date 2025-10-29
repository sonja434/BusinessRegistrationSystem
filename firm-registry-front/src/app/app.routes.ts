import { Routes } from '@angular/router';
import { Home } from './shared/home/home';
import { About } from './pages/about/about';
import { Contact } from './pages/contact/contact';
import { LearnMore } from './pages/learn-more/learn-more';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Profile } from './pages/profile/profile';
import { ActivityCodes, } from './pages/activity-codes/activity-codes';
import { PrGuide } from './guides/pr-guide/pr-guide';
import { DooGuide } from './guides/doo-guide/doo-guide';
import { AdGuide } from './guides/ad-guide/ad-guide';
import { OdGuide } from './guides/od-guide/od-guide';
import { KdGuide } from './guides/kd-guide/kd-guide';
import { CompanyRegistration } from './pages/company-registration/company-registration';
import { CompanyRequestsUser } from './pages/company-requests-user/company-requests-user';
import { CompanyRequestDetail } from './pages/company-requests-detail/company-requests-detail';
import { CompanyRequestsAdmin } from './pages/company-requests-admin/company-requests-admin';
import { CompanyRequestReview } from './pages/company-request-review/company-request-review';

export const routes: Routes = [
  { path: '', component: Home }, 
  { path: 'about', component: About },
  { path: 'contact', component: Contact},
  { path: 'learn-more', component: LearnMore},
  { path: 'login', component: Login},
  { path: 'register', component: Register},
  { path: 'profile', component: Profile },
  { path: 'codes', component: ActivityCodes },
  { path: 'pr', component: PrGuide },
  { path: 'doo', component: DooGuide },
  { path: 'ad', component: AdGuide },
  { path: 'od', component: OdGuide },
  { path: 'kd', component: KdGuide },
  { path: 'register-firm', component: CompanyRegistration },
  { path: 'user-requests', component: CompanyRequestsUser },
  { path: 'request-details/:id', component: CompanyRequestDetail },
  { path: 'admin-requests', component: CompanyRequestsAdmin },
  { path: 'request-review/:id', component: CompanyRequestReview },
  { path: '**', redirectTo: '' }
];
