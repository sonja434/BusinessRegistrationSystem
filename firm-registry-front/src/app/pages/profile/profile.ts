import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { MatDialog } from '@angular/material/dialog';
import { PasswordDialog } from '../password.dialog/password.dialog';


@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
],
  templateUrl: './profile.html',
  styleUrls: ['./profile.css'] // ✅ FIX
})
export class Profile {
  form!: FormGroup;
  editing = false;
  loading = true;
  errorMessage: string | null = null;

  constructor(
    private userService: UserService,
    private fb: FormBuilder,
    private router: Router,
    private dialog: MatDialog
  ) { }

  ngOnInit() {
    this.userService.getProfile().subscribe({
      next: (user) => {
        let d = new Date(user.dateOfBirth);
        d.setDate(d.getDate() + 1);
        const formattedDate = d.toISOString().split('T')[0];

        this.form = this.fb.group({
          firstName: [{ value: user.firstName, disabled: true }],
          lastName: [{ value: user.lastName, disabled: true }],
          jmbg: [{ value: user.jmbg, disabled: true }],
          dateOfBirth: [{ value: formattedDate, disabled: true }],
          residence: [{ value: user.residence, disabled: true }],
          username: [{ value: user.username, disabled: true }],
          email: [{ value: user.email, disabled: true }, [Validators.required, Validators.email]]
        });

        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.errorMessage = 'Greška pri učitavanju profila.';
      }
    });
  }


  enableEdit() {
    this.editing = true;
    this.form.get('email')?.enable();
  }

  save() {
    if (this.form.invalid) return;

    const newEmail = this.form.get('email')?.value;

    const updateData = {
      email: newEmail,
      username: newEmail
    };

    this.userService.updateProfile(updateData).subscribe({
      next: () => {
        this.editing = false;
        this.form.controls['username'].setValue(newEmail);
        this.form.controls['email'].disable();
        this.form.controls['username'].disable();
      },
      error: () => {
        this.errorMessage = 'Greška pri čuvanju podataka.';
      }
    });
  }

  openPasswordDialog() {
    const dialogRef = this.dialog.open(PasswordDialog, {
      width: '500px',
      maxHeight: '100vh',
      panelClass: 'password-dialog-container',
      autoFocus: false,
      restoreFocus: false,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(success => {
      if (success) {
        alert('✅ Lozinka uspešno promenjena.');
      }
    });
  }
}
