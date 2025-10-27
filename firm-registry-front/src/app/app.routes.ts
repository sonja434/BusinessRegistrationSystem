import { Routes } from '@angular/router';
import { Home } from './shared/home/home';
import { About } from './pages/about/about';
import { Contact } from './pages/contact/contact';
import { LearnMore } from './pages/learn-more/learn-more';
import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Profile } from './pages/profile/profile';
import { ActivityCodes, } from './pages/activity-codes/activity-codes';

export const routes: Routes = [
  { path: '', component: Home }, 
  { path: 'about', component: About },
  { path: 'contact', component: Contact},
  { path: 'learn-more', component: LearnMore},
  { path: 'login', component: Login},
  { path: 'register', component: Register},
  { path: 'profile', component: Profile },
  { path: 'codes', component: ActivityCodes },

  { path: '**', redirectTo: '' }
];
