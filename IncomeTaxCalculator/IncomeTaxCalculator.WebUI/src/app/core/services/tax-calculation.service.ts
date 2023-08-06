import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TaxResult } from 'src/app/shared/models/tax-result.model';

@Injectable({
  providedIn: 'root'
})
export class TaxCalculationService {
  private localhost: string = "https://localhost:7078/"

  constructor(private httpClient: HttpClient) { }

  calculateIncomeTax(grossAnnualSalary: number){
    return this.httpClient.post<TaxResult>(this.localhost + "taxcalculation/calculate", {
      grossAnnualSalary: grossAnnualSalary
    });
  }
}
