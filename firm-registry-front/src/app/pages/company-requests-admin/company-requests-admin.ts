import { Component, OnInit } from '@angular/core';
import { CompanyRequestService } from '../../services/company-request.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Router } from '@angular/router';

@Component({
  selector: 'app-company-requests-admin',
  standalone: true, // Dodato radi ispravnosti u novim Angular projektima
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
  ],
  templateUrl: './company-requests-admin.html',
  styleUrl: './company-requests-admin.css'
})
export class CompanyRequestsAdmin implements OnInit {
  displayedColumns: string[] = ['id', 'companyName', 'type', 'status', 'userId', 'createdAt', 'actions'];
  requests: any[] = [];
  loading = false;

  constructor(
    private service: CompanyRequestService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadRequests();
  }

  loadRequests() {
    this.loading = true;
    this.service.getAllRequests().subscribe({
      next: (res) => {
        this.requests = res.items || res.Items || []; 
        
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        this.snackBar.open('Greška pri učitavanju zahteva', 'Zatvori', { duration: 3000 });
      }
    });
  }

  openDetails(id: number) {
    this.router.navigate(['/request-review', id]);
  }

  getStatusLabel(status: number): string {

    const map: any = {
      0: 'Na čekanju',
      1: 'Odobren',
      2: 'Odbijen',
      3: 'Na reviziji',
      4: 'Otkazan'
    };
    return map[status] || 'Nepoznato';
  }
}
