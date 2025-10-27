import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatOptionModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ActivityCodesService } from '../../services/activity-codes.service';
import { Subject, debounceTime, distinctUntilChanged } from 'rxjs';


@Component({
  selector: 'app-activity-codes',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatOptionModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTableModule,
    MatProgressSpinnerModule
  ],
  templateUrl: './activity-codes.html',
  styleUrls: ['./activity-codes.css']
})
export class ActivityCodes implements OnInit {
  codes: any[] = [];
  sectors: any[] = [];
  groups: any[] = [];
  loading = false;

  displayedColumns: string[] = ['code', 'description'];

  selectedSectorId: number | null = null;
  selectedGroupId: number | null = null;
  search: string = '';

  totalCount = 0;
  pageSize = 20;
  pageNumber = 1;

  private searchSubject = new Subject<string>();


  constructor(private activityService: ActivityCodesService) { }

  ngOnInit() {
    this.loadSectors();
    this.loadCodes();
    this.searchSubject
      .pipe(
        debounceTime(400),
        distinctUntilChanged()
      )
      .subscribe(value => {
        this.pageNumber = 1;
        this.search = value;
        this.loadCodes();
      });

  }

  loadSectors() {
    this.activityService.getSectors().subscribe((data: any[]) => {
      this.sectors = data;
    });
  }

  onSectorChange() {
    this.pageNumber = 1;
    this.selectedGroupId = null;
    if (this.selectedSectorId) {
      this.activityService.getGroups(this.selectedSectorId).subscribe(data => {
        this.groups = data;
        this.loadCodes();
      });
    } else {
      this.groups = [];
      this.loadCodes();
    }
  }

  onGroupChange() {
    this.pageNumber = 1;
    this.loadCodes();
  }


  loadCodes() {
    this.loading = true;

    this.activityService
      .getCodes(this.pageNumber, this.pageSize, this.search, this.selectedSectorId, this.selectedGroupId)
      .subscribe({
        next: (result: { items: any[]; totalCount: number; }) => {
          this.codes = result.items;
          this.totalCount = result.totalCount;
          this.loading = false;
        },
        error: () => (this.loading = false)
      });
  }

  onPageChange(event: PageEvent) {
    this.pageNumber = event.pageIndex + 1;
    this.pageSize = event.pageSize;
    this.loadCodes();
  }

  onSearchChange(event: any) {
    const value = event.target.value.trim();
    this.searchSubject.next(value);
  }

  clearSearch() {
    this.search = '';
    this.pageNumber = 1;
    this.loadCodes();
  }

}
