import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyRequestService } from '../../services/company-request.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatProgressSpinnerModule, MatSpinner } from '@angular/material/progress-spinner';
import { HttpClientModule } from '@angular/common/http';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'app-company-request-review',
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatListModule,
    MatDividerModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './company-request-review.html',
  styleUrl: './company-request-review.css'
})
export class CompanyRequestReview implements OnInit {
  request: any;
  allMembers: any[] = [];
  loading = false;
  id!: number;

  // Admin-specific fields
  newStatus: number | null = null;
  adminNotes: string = '';

  constructor(
    private route: ActivatedRoute,
    private service: CompanyRequestService,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.loadRequest();
  }

  loadRequest() {
    this.loading = true;
    this.service.getRequest(this.id).subscribe({
      next: (res) => {
        this.request = res;
        this.collectMembers();
        this.loading = false;
        this.newStatus = this.request.status;
        this.adminNotes = this.request.adminNotes || '';
      },
      error: () => {
        this.loading = false;
        this.snackBar.open('Greška pri učitavanju zahteva', 'Zatvori', { duration: 3000 });
      }
    });
  }

  collectMembers() {
    this.allMembers = [
      ...(this.request.owner ? [this.request.owner] : []),
      ...(this.request.founders || []),
      ...(this.request.shareholders || []),
      ...(this.request.partners || []),
      ...(this.request.generalPartners || []),
      ...(this.request.limitedPartners || [])
    ];
  }

  getCompanyType(type: number): string {
    const map: any = {
      0: 'PR - Preduzetnik',
      1: 'DOO - Društvo sa ograničenom odgovornošću',
      2: 'AD - Akcionarsko društvo',
      3: 'OD - Ortakluk',
      4: 'KD - Komanditno društvo'
    };
    return map[type] || 'Nepoznato';
  }

  getRequestStatus(status: number): string {
    const map: any = {
      0: 'Na čekanju',
      1: 'Odobren',
      2: 'Odbijen',
      3: 'Na reviziji',
      4: 'Otkazan'
    };
    return map[status] || 'Nepoznato';
  }

  updateByAdmin() {
    if (this.newStatus === null) {
      this.snackBar.open('Izaberi novi status', 'Zatvori', { duration: 2500 });
      return;
    }

    const dto = {
      status: this.newStatus,
      adminNotes: this.adminNotes
    };

    this.service.updateRequestByAdmin(this.id, dto).subscribe({
      next: () => {
        this.snackBar.open('Zahtev uspešno ažuriran', 'Zatvori', { duration: 3000 });
        this.loadRequest();
      },
      error: () => this.snackBar.open('Greška pri ažuriranju zahteva', 'Zatvori', { duration: 3000 })
    });
  }

  downloadDocument(docName: string) {
    if (!this.request || !this.request.id || !docName) return;

    this.service.downloadDocument(this.request.id, docName).subscribe({
      next: (blob: Blob) => {
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = docName;
        a.click();
        window.URL.revokeObjectURL(url);
      },
      error: () => {
        this.snackBar.open('Greška pri preuzimanju dokumenta', 'Zatvori', { duration: 3000 });
      }
    });
  }

}