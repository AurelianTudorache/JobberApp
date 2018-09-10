import { Component, OnInit, Inject } from '@angular/core';
import { FormFieldStateMatcher } from '../../../shared/modules/angular-material-components/formfield.statematcher';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { SaveEmployerBusinessDetails } from '../../../shared/interfaces/SaveEmployerBusinessDetails';
import { EmployerBusinessDetails } from '../../../shared/interfaces/EmployerBusinessDetails';

@Component({
  selector: 'app-business-details',
  templateUrl: './business-details.component.html',
  styleUrls: ['./business-details.component.css']
})
export class BusinessDetailsComponent implements OnInit {

  form: FormGroup;

  private readonly employerUrl = "api/employer";

  matcher = new FormFieldStateMatcher();

  public companyNameFC = new FormControl('');
  public companyEmailFC = new FormControl('', [Validators.email]);
  public companyNumberFC = new FormControl('');
  public vatNumberFC = new FormControl('');
  public hqCityFC = new FormControl('');
  public hqStreetFC = new FormControl('');
  public hqBuildingFC = new FormControl('');
  public hqPostalCodeFC = new FormControl('');


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sb: MatSnackBar, private fb: FormBuilder) {
    this.form = fb.group({
      id: 0,
      companyEmail: this.companyEmailFC,
      companyName: this.companyNameFC,
      companyNumber: this.companyNumberFC,
      vatNumber: this.vatNumberFC,
      hqCity: this.hqCityFC,
      hqStreet: this.hqStreetFC,
      hqBuilding: this.hqBuildingFC,
      hqPostalCode: this.hqPostalCodeFC
    });
   }

  ngOnInit() {
    this.http.get<EmployerBusinessDetails>(this.baseUrl + this.employerUrl).subscribe(result => {
      this.form.patchValue(result);
    }, error => this.sb.open(error, 'close', { duration: 5000 }));
  }

  submit() {
    this.http.put<SaveEmployerBusinessDetails>(this.employerUrl + '/' + this.form.value.id, this.form.value).subscribe(employerBD => {
      this.sb.open('The request was successfully submitted.', 'close', { duration: 5000 });
    }, error =>  this.sb.open(error, 'close', { duration: 5000 }));
  }

  public get formOk(): boolean {
    return this.form.valid
  }

}
