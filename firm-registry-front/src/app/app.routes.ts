import { Routes } from '@angular/router';
import { Home } from './shared/home/home';
import { About } from './pages/about/about';
import { Contact } from './pages/contact/contact';
import { LearnMore } from './pages/learn-more/learn-more';
import { Login } from './pages/login/login';

export const routes: Routes = [
  { path: '', component: Home }, 
  { path: 'about', component: About },
  { path: 'contact', component: Contact},
  { path: 'learn-more', component: LearnMore},
  { path: 'login', component: Login},
  { path: '**', redirectTo: '' }
];
