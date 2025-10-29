import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
  FormsModule,
  AbstractControl,
} from '@angular/forms';
import { MatStepper, MatStepperModule } from '@angular/material/stepper';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { CompanyRequestService } from '../../services/company-request.service';
import { ActivityCodesService } from '../../services/activity-codes.service';
import { Router } from '@angular/router';

interface Address { street: string; number: number | null; city: string; country: string; }
interface CompanyRequest {
  companyName: string;
  activityCodeId: number;
  address: Address;
  type: string; 
  [key: string]: any; 
}

interface ActivitySector { id: number; name: string; }
interface ActivityGroup { id: number; name: string; }
interface ActivityCode { id: number; code: string; description: string; }


@Component({
  selector: 'app-company-registration',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatStepperModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    MatListModule,
    MatDividerModule,
    MatSelectModule,
  ],
  templateUrl: './company-registration.html',
  styleUrls: ['./company-registration.css']
})
export class CompanyRegistration implements OnInit {
  @ViewChild('stepper') stepper!: MatStepper;
  @ViewChild('fileInput') fileInput!: ElementRef;

  generalForm!: FormGroup;
  typeForm!: FormGroup;
  specificForm!: FormGroup;
  documentForm!: FormGroup;
  reviewForm!: FormGroup;

  selectedFiles: File[] = [];
  isSubmitting = false;

  private CompanyTypeEnumMap: { [key: string]: number } = {
    'PR': 0,
    'DOO': 1,
    'AD': 2,
    'OD': 3,
    'KD': 4,
  };

  sectors: ActivitySector[] = [];
  groups: ActivityGroup[] = [];
  codes: ActivityCode[] = [];
  private codeDescriptionMap = new Map<number, string>();

  constructor(
    private fb: FormBuilder, 
    private service: CompanyRequestService,
    private activityService: ActivityCodesService,
    private router: Router
  ) {}

  ngOnInit() {
    this.generalForm = this.fb.group({
      companyName: ['', Validators.required],
      activitySectorId: [null, Validators.required], 
      activityGroupId: [{ value: null, disabled: true }, Validators.required],
      activityCodeId: [{ value: null, disabled: true }, Validators.required], 
      address: this.fb.group({
        street: ['', Validators.required],
        number: [1, [Validators.required, Validators.min(1)]],
        city: ['', Validators.required],
        country: ['', Validators.required]
      })
    });

    this.typeForm = this.fb.group({
      companyType: ['PR', Validators.required]
    });

    this.documentForm = this.fb.group({}); 
    this.reviewForm = this.fb.group({}); 

    this.typeForm.get('companyType')!.valueChanges.subscribe(type => {
      this.buildSpecificForm(type);
      this.specificForm.markAllAsTouched();
    });

    this.buildSpecificForm(this.typeForm.value.companyType);

    this.loadSectors();
    this.setupActivityCodeListeners();
  }


  loadSectors() {
    this.activityService.getSectors().subscribe({
      next: (data: ActivitySector[]) => {
        this.sectors = data;
      },
      error: (err) => {
        console.error('Greška pri učitavanju sektora', err);
      }
    });
  }

  loadGroups(sectorId: number) {
    this.activityService.getGroups(sectorId).subscribe({
      next: (data: ActivityGroup[]) => {
        this.groups = data;
      },
      error: (err) => {
        console.error('Greška pri učitavanju grupa', err);
      }
    });
  }

  setupActivityCodeListeners() {
    this.generalForm.get('activitySectorId')?.valueChanges.subscribe(sectorId => {
      this.groups = [];
      this.codes = [];
      this.generalForm.get('activityGroupId')?.setValue(null, { emitEvent: false });
      this.generalForm.get('activityCodeId')?.setValue(null, { emitEvent: false });
      
      if (sectorId) {
        this.loadGroups(sectorId);
        this.generalForm.get('activityGroupId')?.enable({ emitEvent: false });
      } else {
        this.generalForm.get('activityGroupId')?.disable({ emitEvent: false });
      }
      this.generalForm.get('activityCodeId')?.disable({ emitEvent: false });
    });

    this.generalForm.get('activityGroupId')?.valueChanges.subscribe(groupId => {
      this.codes = [];
      this.generalForm.get('activityCodeId')?.setValue(null, { emitEvent: false });

      if (groupId) {
        this.activityService.getCodes(
            1, 999,
            undefined, 
            this.generalForm.get('activitySectorId')?.value,
            groupId
          )
          .subscribe({
            next: (result: { items: ActivityCode[]; totalCount: number; }) => {
              this.codes = result.items.filter(code => code.id !== null);
              
              this.codeDescriptionMap.clear();
              this.codes.forEach(code => {
                this.codeDescriptionMap.set(code.id, `${code.code} - ${code.description}`);
              });

              if (this.codes.length > 0) {
                 this.generalForm.get('activityCodeId')?.enable({ emitEvent: false });
              } else {
                 this.generalForm.get('activityCodeId')?.disable({ emitEvent: false });
              }
            },
            error: (err) => {
              console.error('Greška pri učitavanju kodova', err);
              this.generalForm.get('activityCodeId')?.disable({ emitEvent: false });
            }
          });
      } else {
        this.generalForm.get('activityCodeId')?.disable({ emitEvent: false });
      }
    });
  }
  
  public getCodeDescription(): string {
    const codeId = this.generalForm.get('activityCodeId')?.value;
    if (!codeId) {
      return '';
    }
    return this.codeDescriptionMap.get(codeId) || '';
  }

  private buildFounder(includeShare: boolean = false): FormGroup {
    const group: { [key: string]: any } = {
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      jmbg: ['', [Validators.required, Validators.pattern(/^\d{13}$/)]], 
      address: this.fb.group({
        street: ['', Validators.required],
        number: [1, [Validators.required, Validators.min(1)]],
        city: ['', Validators.required],
        country: ['', Validators.required]
      }),
    };

    if (includeShare) {
      group['share'] = [null, [Validators.required, Validators.min(0), Validators.max(100)]];
    } else {
      group['share'] = [null]; 
    }

    return this.fb.group(group);
  }

  private atLeastOneValid(control: AbstractControl) {
    const arr = control as FormArray;
    return arr && arr.length > 0 && arr.valid ? null : { atLeastOne: true };
  }

  buildSpecificForm(type: string) {
    this.specificForm = this.fb.group({});
    
    switch (type) {
      case 'PR':
        this.specificForm.addControl('owner', this.buildFounder(false));
        break;

      case 'DOO':
        this.specificForm = this.fb.group(
          {
            directorFullName: ['', Validators.required],
            shareCapital: [100, [Validators.required, Validators.min(100)]],
            founders: this.fb.array([this.buildFounder(true)], [this.atLeastOneValid])
          },
          { validators: this.validateTotalShare(['founders']) }
        );
        break;

      case 'AD':
        this.specificForm = this.fb.group(
          {
            shareCapital: [3000000, [Validators.required, Validators.min(3000000)]],
            shareholders: this.fb.array([this.buildFounder(true)], [this.atLeastOneValid]),
            boardOfDirectors: this.fb.array([this.fb.control('', Validators.required)], [this.atLeastOneValid])
          },
          { validators: this.validateTotalShare(['shareholders']) }
        );
        break;

      case 'OD':
        this.specificForm.addControl('partners', this.fb.array([this.buildFounder(false)], [this.atLeastOneValid]));
        break;

      case 'KD':
        this.specificForm = this.fb.group(
          {
            generalPartners: this.fb.array([this.buildFounder(true)], [this.atLeastOneValid]),
            limitedPartners: this.fb.array([this.buildFounder(true)], [this.atLeastOneValid])
          },
          { validators: this.validateTotalShare(['generalPartners', 'limitedPartners']) }
        );
        break;
    }
  }

  private validateTotalShare(arrayNames: string[]) {
    return (group: AbstractControl) => {
      let total = 0;
      let allValid = true;

      arrayNames.forEach(arrName => {
        const arr = group.get(arrName) as FormArray;
        if (arr) {
          total += arr.controls.reduce((sum, c) => sum + (c.get('share')?.value || 0), 0);
          if (arr.invalid) allValid = false;
        }
      });
      
      if (total !== 100 && allValid) {
          return { totalShare: true };
      }
      
      return null;
    }
  }

  get founders() { return this.specificForm.get('founders') as FormArray; }
  get shareholders() { return this.specificForm.get('shareholders') as FormArray; }
  get partners() { return this.specificForm.get('partners') as FormArray; }
  get generalPartners() { return this.specificForm.get('generalPartners') as FormArray; }
  get limitedPartners() { return this.specificForm.get('limitedPartners') as FormArray; }
  get boardMembers() { return this.specificForm.get('boardOfDirectors') as FormArray; }

  addFounder() { this.founders.push(this.buildFounder(true)); }
  removeFounder(i: number) { this.founders.removeAt(i); }

  addShareholder() { this.shareholders.push(this.buildFounder(true)); }
  removeShareholder(i: number) { this.shareholders.removeAt(i); }

  addPartner() { this.partners.push(this.buildFounder(false)); }
  removePartner(i: number) { this.partners.removeAt(i); }

  addGeneralPartner() { this.generalPartners.push(this.buildFounder(true)); }
  removeGeneralPartner(i: number) { this.generalPartners.removeAt(i); }

  addLimitedPartner() { this.limitedPartners.push(this.buildFounder(true)); }
  removeLimitedPartner(i: number) { this.limitedPartners.removeAt(i); }

  addBoardMember() { this.boardMembers.push(this.fb.control('', Validators.required)); }
  removeBoardMember(i: number) { this.boardMembers.removeAt(i); }

  onFilesSelected(files: FileList | null) {
    if (!files) return;
    Array.from(files).forEach(f => {
      if (!this.selectedFiles.some(sf => sf.name === f.name && sf.size === f.size)) this.selectedFiles.push(f);
    });
    if (this.fileInput) {
        (this.fileInput.nativeElement as HTMLInputElement).value = '';
    }
  }
  removeFile(i: number) { this.selectedFiles.splice(i, 1); }

  submitRequest() {
    this.generalForm.markAllAsTouched();
    this.typeForm.markAllAsTouched();
    this.specificForm.markAllAsTouched();

    if (this.generalForm.invalid || this.typeForm.invalid || this.specificForm.invalid) {
      console.warn('Forma nije kompletno i validno popunjena.');
      if (this.generalForm.invalid) this.stepper.selectedIndex = 0;
      else if (this.typeForm.invalid) this.stepper.selectedIndex = 1;
      else if (this.specificForm.invalid) this.stepper.selectedIndex = 2;
      return;
    }

    const rawRequestData: CompanyRequest = {
        ...this.generalForm.getRawValue(), 
        ...this.specificForm.value,
        type: this.typeForm.value.companyType 
    } as CompanyRequest;
    
    delete rawRequestData['activitySectorId'];
    delete rawRequestData['activityGroupId'];

    const requestDataForBackend = {
        ...rawRequestData,
        "Type": this.CompanyTypeEnumMap[rawRequestData.type] 
    };
    
    delete (requestDataForBackend as any)['type'];

    const data = new FormData();
    data.append('request', JSON.stringify(requestDataForBackend)); 
    
    this.selectedFiles.forEach(f => data.append('DocumentFiles', f, f.name)); 

    this.isSubmitting = true;
    this.service.createRequest(data).subscribe({
      next: res => {
        console.log('Uspešno poslato:', res);
        alert('Zahtev je uspešno poslat! 🎉');
        this.router.navigate(['/']);
        this.stepper.reset();
        this.selectedFiles = [];
        this.isSubmitting = false;
        this.buildSpecificForm(this.typeForm.value.companyType); 
      },
      error: err => {
        console.error('Greška prilikom slanja:', err);
        alert('Došlo je do greške prilikom slanja zahteva. Proverite konzolu.');
        this.isSubmitting = false;
      }
    });
  }
}