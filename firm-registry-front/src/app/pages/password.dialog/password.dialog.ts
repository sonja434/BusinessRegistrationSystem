import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef } from '@angular/material/dialog';
import { UserService } from '../../services/user.service';
import { MatIcon } from '@angular/material/icon';
import { MatSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-password.dialog',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIcon,
    MatSpinner
  ],
  templateUrl: './password.dialog.html',
  styleUrl: './password.dialog.css'
})
export class PasswordDialog {

  form: FormGroup;
  loading = false;
  errorMessage: string | null = null;
  hideCurrent = true;
  hideNew = true;
  hideConfirm = true;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private dialogRef: MatDialogRef<PasswordDialog>
  ) {
    this.form = this.fb.group(
      {
        currentPassword: ['', Validators.required],
        newPassword: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', Validators.required]
      },
      { validators: this.passwordsMatch }
    );
  }

  passwordsMatch(form: FormGroup) {
    const newPass = form.get('newPassword')?.value;
    const confirm = form.get('confirmPassword')?.value;
    return newPass === confirm ? null : { mismatch: true };
  }

  changePassword() {
    if (this.form.invalid) return;

    this.loading = true;
    this.errorMessage = null;

    const dto = {
      currentPassword: this.form.value.currentPassword,
      newPassword: this.form.value.newPassword
    };

    this.userService.changePassword(dto).subscribe({
      next: () => {
        this.loading = false;
        this.dialogRef.close(true);
      },
      error: () => {
        this.loading = false;
        this.errorMessage = "❌ Trenutna lozinka nije tačna.";
      }
    });
  }

  close() {
    this.dialogRef.close(false);
  }
}
