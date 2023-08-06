import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, catchError, throwError } from 'rxjs';
import { TaxCalculationService } from 'src/app/core/services/tax-calculation.service';
import { TaxResult } from 'src/app/shared/models/tax-result.model';

@Component({
  selector: 'tax-calculation',
  templateUrl: './tax-calculation.component.html',
  styleUrls: ['./tax-calculation.component.scss']
})
export class TaxCalculationComponent implements OnInit {

  public result: Observable<TaxResult>;
  public grossAnnualSalaryForm: FormGroup
  public errorMsg: string | null;

  constructor(private taxCalculationService: TaxCalculationService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.grossAnnualSalaryForm = this.formBuilder.group({
      annualGrossSalary: [""]
    });
  }

  calculateTax(){
    this.errorMsg = null;
    this.result = this.taxCalculationService.calculateIncomeTax(this.grossAnnualSalaryForm.get("annualGrossSalary")?.value)
    .pipe(
      catchError((error: HttpErrorResponse) => {
        this.errorMsg = error.error.errors["GrossAnnualSalary"];
        return throwError(() => error)
      })
    );
  }

  filterInput(event: any){
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode !== 45 && charCode !== 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
      this.errorMsg = "Please, enter only numeric value";
      return false;
    }
    this.errorMsg = null;
    return true;
  }

}
