import { Component, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { AuthService } from '../../services/auth.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule
  ],
  templateUrl: './navbar.html',
  styleUrls: ['./navbar.css']
})
export class Navbar implements OnDestroy {

  isLoggedIn = false;
  isAdmin = false;
  email: string | null = null;
  private sub = new Subscription();

  constructor(private auth: AuthService) {
    this.sub.add(
      this.auth.authChanges().subscribe(val => {
        this.isLoggedIn = val;
        this.isAdmin = this.auth.getUserRole() === 'Admin';
        this.email = this.auth.getEmail();
      })
    );
  }

  logout() {
    this.auth.logout();
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }
}
