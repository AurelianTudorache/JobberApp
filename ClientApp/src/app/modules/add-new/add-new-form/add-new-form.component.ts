import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Skill } from '../../../shared/interfaces/skill';
import { HttpClient } from '@angular/common/http';
import { SaveJobAd } from '../../../shared/interfaces/saveJobAd';
import { JobAd } from '../../../shared/interfaces/jobAd';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { FormFieldStateMatcher } from '../../../shared/modules/angular-material-components/formfield.statematcher';
import { Observable, forkJoin, combineLatest } from 'rxjs';
import { JobLocation } from '../../../shared/interfaces/jobLocation';

@Component({
  selector: 'app-add-new-form',
  templateUrl: './add-new-form.component.html',
  styleUrls: ['./add-new-form.component.css']
})
export class AddNewFormComponent implements OnInit {

  minDate = new Date();

  form: FormGroup;

  private readonly skillsUrl = "api/skills";
  private readonly locationsUrl = "api/employer/locations";
  private readonly jobAdUrl = "api/employer/newjob";

  matcher = new FormFieldStateMatcher();

  public nameFC = new FormControl('', [Validators.required]);
  public skillsFC = new FormControl('', [Validators.required]);
  public locationsFC = new FormControl('', [Validators.required]);
  public positionsFC = new FormControl('', [Validators.required]);
  public descriptionFC = new FormControl('', [Validators.required]);
  public requirmentsFC = new FormControl('', [Validators.required]);
  public startDateFC = new FormControl('', [Validators.required]);
  public endDateFC = new FormControl('', [Validators.required]);
  public durationFC = new FormControl('', [Validators.required]);
  public payRateFC = new FormControl('', [Validators.required]);

  skills: any[];
  locations: any[];
  positions = [
    {value: '1', viewValue: '1'},
    {value: '2', viewValue: '2'},
    {value: '3', viewValue: '3'}
  ];


  constructor(private http: HttpClient, private sb: MatSnackBar, private fb: FormBuilder, @Inject('BASE_URL') private baseUrl: string) { 

      this.form = fb.group({
        id: 0,
        name: this.nameFC,
        description: this.descriptionFC,
        skillId: this.skillsFC,
        locationId: this.locationsFC,
        posNeeded: this.positionsFC,
        requirments: this.requirmentsFC,
        startDate: this.startDateFC,
        endDate: this.endDateFC,
        duration: this.durationFC,
        payRate: this.payRateFC,
        chargeRate: 0,
        totalCharge: 0
      });
    }
    
    ngOnInit() {      
      let sources = [
        this.http.get<Skill[]>(this.baseUrl + this.skillsUrl),
        this.http.get<JobLocation[]>(this.baseUrl + this.locationsUrl)
      ];
      
      forkJoin(sources).subscribe(data => {
        
        this.skills = data[0];
        this.locations = data[1]; 
        
      }, error => { this.sb.open(error, 'close', { duration: 5000 });         
    });

    this.charges();
  }

  formReset(){
    // location.reload();
    // this.form.reset();
    // Object.keys(this.form.controls).forEach(key => {
    //   this.form.controls[key].setErrors(null)
    // });
  }

  charges() {
    combineLatest(
      this.payRateFC.valueChanges,
      this.durationFC.valueChanges,
      this.positionsFC.valueChanges
    )
    .subscribe(([val1, val2, val3]) => {      
      this.form.patchValue({ chargeRate: val1 * 1.19, totalCharge: val2 * (val1 * 1.19) * val3 });
    });  

  }
  
  submit() {
    this.http.post<SaveJobAd>(this.jobAdUrl, this.form.value).subscribe(jobAd => {
      location.reload();
      
      this.sb.open('The job was successfully added.', 'close', { duration: 5000 });
    }, error => this.sb.open(error, 'close', { duration: 5000 }));
  }

  public get formOk(): boolean {
    return this.form.valid 
  }

}
