import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { Router, RouterModule } from '@angular/router';
import { CompanyRequestService } from '../../services/company-request.service';

@Component({
  selector: 'app-company-requests-user',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    RouterModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './company-requests-user.html',
  styleUrls: ['./company-requests-user.css']
})
export class CompanyRequestsUser implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'companyName', 'type', 'status', 'createdAt', 'updatedAt', 'actions'];
  dataSource = new MatTableDataSource<any>([]);
  totalCount = 0;
  pageSize = 10;
  currentPage = 1;
  loading = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private companyRequestService: CompanyRequestService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadRequests();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  loadRequests(): void {
    this.loading = true;
    const queryParams = { page: this.currentPage, pageSize: this.pageSize };

    this.companyRequestService.getUserRequests(queryParams).subscribe({
      next: (res: any) => {
        const items = res.items || res.Items || [];
        this.dataSource.data = items.map((x: any) => ({
          id: x.id,
          companyName: x.companyName,
          type: this.mapCompanyType(x.type),
          status: this.mapRequestStatus(x.status),
          createdAt: x.createdAt,
          updatedAt: x.updatedAt
        }));

        this.totalCount = res.totalCount || res.TotalCount || this.dataSource.data.length;
        this.loading = false;
      },
      error: (err: any) => {
        console.error('Greška prilikom učitavanja zahteva:', err);
        this.loading = false;
      }
    });
  }

  onPageChange(event: PageEvent): void {
    this.currentPage = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadRequests();
  }

  openDetails(request: any): void {
    this.router.navigate(['/request-details', request.id]);
  }

  private mapCompanyType(value: number | string): string {
    const map = ['PR', 'DOO', 'AD', 'OD', 'KD'];
    return typeof value === 'number' ? map[value] || '-' : value;
  }

  private mapRequestStatus(value: number | string): string {
    const map = ['Pending', 'Approved', 'Rejected', 'Revision', 'Cancelled'];
    return typeof value === 'number' ? map[value] || '-' : value;
  }
}
