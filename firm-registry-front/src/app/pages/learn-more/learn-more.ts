import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCard, MatCardContent, MatCardHeader, MatCardModule, MatCardTitle } from '@angular/material/card';
import { MatIcon } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-learn-more',
  imports: [
    CommonModule,
    MatCardModule,
    MatIcon,
    RouterModule
  ],
  templateUrl: './learn-more.html',
  styleUrl: './learn-more.css'
})
export class LearnMore {

}
