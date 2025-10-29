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

// --- INTERFEJSI ZA TIPSKU SIGURNOST ---
interface Address { street: string; number: number | null; city: string; country: string; }
interface CompanyRequest {
  companyName: string;
  activityCodeId: number;
  address: Address;
  type: string; // Polje koje se koristi za polimorfizam (npr. 'PR', 'DOO')
  [key: string]: any; 
}

// Novi interfejsi za Šifre delatnosti
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

  // 🔴 KLJUČNA IZMENA 1: MAPA ZA KONVERZIJU TIPA FIRME U NUMERIČKU VREDNOST (INT)
  private CompanyTypeEnumMap: { [key: string]: number } = {
    'PR': 0,
    'DOO': 1,
    'AD': 2,
    'OD': 3,
    'KD': 4,
  };

  // --- NOVE VARIJABLE ZA KASKADNI IZBOR DELATNOSTI ---
  sectors: ActivitySector[] = [];
  groups: ActivityGroup[] = [];
  codes: ActivityCode[] = [];
  private codeDescriptionMap = new Map<number, string>();
  // ---------------------------------------------------

  constructor(
    private fb: FormBuilder, 
    private service: CompanyRequestService,
    private activityService: ActivityCodesService,
    private router: Router
  ) {}

  ngOnInit() {
    this.generalForm = this.fb.group({
      companyName: ['', Validators.required],
      // Kontrole za kaskadni izbor
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

    // Reagovanje na promenu tipa firme
    this.typeForm.get('companyType')!.valueChanges.subscribe(type => {
      this.buildSpecificForm(type);
      this.specificForm.markAllAsTouched();
    });

    // Inicijalna izgradnja forme (za PR)
    this.buildSpecificForm(this.typeForm.value.companyType);

    // --- LOGIKA ZA KASKADNI IZBOR DELATNOSTI ---
    this.loadSectors();
    this.setupActivityCodeListeners();
  }

  // ------------------------------------------
  // ## LOGIKA ZA NKD (ŠIFRE DELATNOSTI)
  // ------------------------------------------

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
    // 1. Osluškivanje promene Sektora
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

    // 2. Osluškivanje promene Grupe
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

  // ------------------------------------------
  // ## LOGIKA ZA FORME (Osnivači, Partneri, Validacija udela)
  // ------------------------------------------

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

  // --- Getteri za FormArray ---
  get founders() { return this.specificForm.get('founders') as FormArray; }
  get shareholders() { return this.specificForm.get('shareholders') as FormArray; }
  get partners() { return this.specificForm.get('partners') as FormArray; }
  get generalPartners() { return this.specificForm.get('generalPartners') as FormArray; }
  get limitedPartners() { return this.specificForm.get('limitedPartners') as FormArray; }
  get boardMembers() { return this.specificForm.get('boardOfDirectors') as FormArray; }

  // --- Metode za dodavanje/brisanje članova FormArray ---
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

  // --- Logika za fajlove ---
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

  
  // ------------------------------------------
  // ## GLAVNA METODA ZA SLANJE (FINALNO KORIGOVANO)
  // ------------------------------------------

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

    // 1. KREIRANJE KOMPLETNOG REQUEST OBJEKTA (u camelCase formatu)
    const rawRequestData: CompanyRequest = {
        // Koristimo getRawValue() za preuzimanje vrednosti iz disabled kontrola
        ...this.generalForm.getRawValue(), 
        ...this.specificForm.value,
        type: this.typeForm.value.companyType // Ključ za polimorfizam (npr. "PR")
    } as CompanyRequest;
    
    // Uklanjamo pomoćna polja (koja služe samo za kaskadni izbor na frontu)
    delete rawRequestData['activitySectorId'];
    delete rawRequestData['activityGroupId'];

    
    // 🔴 KLJUČNA IZMENA 2: KONVERZIJA TIPA FIRME IZ STRINGA U NUMERIČKI ENUM.
    // C# DTO očekuje PascalCase 'Type' sa int vrednošću (0, 1, 2...)
    const requestDataForBackend = {
        ...rawRequestData,
        // ⚠️ Koristimo mapu za konverziju stringa u broj!
        "Type": this.CompanyTypeEnumMap[rawRequestData.type] 
    };
    
    // Uklanjamo originalni camelCase 'type' string da ne bi došlo do konflikta
    delete (requestDataForBackend as any)['type'];

    // 2. PAKOVANJE U FORMDATA (za slanje fajlova i JSON-a)
    const data = new FormData();
    // Sada šaljemo JSON string sa {"Type": 0} ili {"Type": 1}, što je ono što C# očekuje.
    data.append('request', JSON.stringify(requestDataForBackend)); 
    
    // 3. Dodavanje fajlova pod ključem 'DocumentFiles'
    this.selectedFiles.forEach(f => data.append('DocumentFiles', f, f.name)); 

    this.isSubmitting = true;
    this.service.createRequest(data).subscribe({
      next: res => {
        console.log('Uspešno poslato:', res);
        alert('Zahtev je uspešno poslat! 🎉');
        this.router.navigate(['/']);
        // Resetovanje stanja nakon uspešnog slanja
        this.stepper.reset();
        this.selectedFiles = [];
        this.isSubmitting = false;
        // Ponavno postavljanje inicijalne forme nakon resetovanja
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