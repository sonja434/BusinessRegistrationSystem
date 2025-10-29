import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CompanyRequestService } from '../../services/company-request.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-company-request-detail',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatListModule,
    MatDividerModule,
  ],
  templateUrl: './company-requests-detail.html',
  styleUrls: ['./company-requests-detail.css']
})
export class CompanyRequestDetail implements OnInit {
  request: any;
  allMembers: any[] = [];
  newDocuments: File[] = [];
  loading = false;
  id!: number;
  existingDocuments: string[] = [];

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
        this.existingDocuments = [...(this.request.documents || [])];
        this.collectMembers();
        this.loading = false;
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

  onFileSelected(event: any) {
    const files = Array.from(event.target.files) as File[];
    this.newDocuments.push(...files);
    event.target.value = '';
  }

  removeDocument(doc: string) {
    this.existingDocuments = this.existingDocuments.filter(d => d !== doc);
  }

  removeNewDocument(file: File) {
    this.newDocuments = this.newDocuments.filter(f => f !== file);
  }

  updateRequest() {
    const formData = new FormData();

    this.existingDocuments.forEach(doc =>
      formData.append('ExistingDocuments', doc)
    );

    this.newDocuments.forEach(file =>
      formData.append('DocumentFiles', file)
    );

    formData.append('CancelRequest', 'false');

    this.service.updateRequestByUser(this.id, formData).subscribe({
      next: () => {
        this.snackBar.open('Zahtev uspešno ažuriran', 'Zatvori', { duration: 3000 });
        this.loadRequest();
        this.newDocuments = [];
      },
      error: () => this.snackBar.open('Greška pri ažuriranju', 'Zatvori', { duration: 3000 })
    });
  }


  cancelRequest() {
    const formData = new FormData();
    formData.append('CancelRequest', 'true');

    this.service.updateRequestByUser(this.id, formData).subscribe({
      next: () => {
        this.snackBar.open('Zahtev otkazan', 'Zatvori', { duration: 3000 });
        this.loadRequest();
      },
      error: () => this.snackBar.open('Greška pri otkazivanju', 'Zatvori', { duration: 3000 })
    });
  }

  downloadPdf() {
    this.service.downloadRequestPdf(this.id).subscribe({
      next: (data) => {
        const blob = new Blob([data], { type: 'application/pdf' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = `Zahtev_${this.id}.pdf`;
        link.click();
      },
      error: () => this.snackBar.open('Greška pri preuzimanju PDF-a', 'Zatvori', { duration: 3000 })
    });
  }

  downloadDocument(fileName: string) {
    this.service.downloadDocument(this.id, fileName).subscribe({
      next: (fileBlob) => {
        const url = window.URL.createObjectURL(fileBlob);
        const a = document.createElement('a');
        a.href = url;
        a.download = fileName;
        a.click();
        window.URL.revokeObjectURL(url);
      },
      error: () => {
        this.snackBar.open('Greška pri preuzimanju dokumenta', 'Zatvori', { duration: 3000 });
      }
    });
  }

  isCancelled(): boolean {
    return this.request?.status === 1 || this.request?.status === 2 || this.request?.status === 4;
  }

}
