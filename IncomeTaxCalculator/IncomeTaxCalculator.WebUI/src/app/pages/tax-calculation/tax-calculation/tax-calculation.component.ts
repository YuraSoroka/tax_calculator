import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
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

  constructor(private taxCalculationService: TaxCalculationService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.grossAnnualSalaryForm = this.formBuilder.group({
      annualGrossSalary: ["", Validators.required]
    });
  }

  calculateTax(){

    this.result = this.taxCalculationService.calculateIncomeTax(this.grossAnnualSalaryForm.get("annualGrossSalary")?.value);
  }

}
