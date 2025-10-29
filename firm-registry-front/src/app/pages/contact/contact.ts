import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-contact',
  imports: [
    MatIcon,
    CommonModule
  ],
  templateUrl: './contact.html',
  styleUrl: './contact.css'
})
export class Contact {

}
