import { UserRegistration } from './../../../shared/interfaces/user-registration';
import { FormFieldStateMatcher } from './../../../shared/modules/angular-material-components/formfield.statematcher';
import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators, FormBuilder, FormGroup, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { confirmPasswordValidator } from './registration.password-confirm.validator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

    form: FormGroup;

    matcher = new FormFieldStateMatcher();
    
    public username = new FormControl('', [Validators.required]);
    public password = new FormControl('', [Validators.required]);
    public email = new FormControl('', [Validators.required, Validators.email]);
    public displayName = new FormControl('', [Validators.required]);
    public passwordConfirm = new FormControl('', [Validators.required, confirmPasswordValidator(this.password)]);


  constructor(private router: Router, private sb: MatSnackBar, private http: HttpClient,  @Inject('BASE_URL') private baseUrl: string, private fb: FormBuilder) { 

        this.form = this.fb.group({
            username: this.username,
            email: this.email,
            password: this.password,
            passwordConfirm: this.passwordConfirm,
            displayName: this.displayName
        });
      }



  onSubmit() {
    // build a temporary user object from form values
    var tempUser = <UserRegistration>{};
    tempUser.userName = this.form.value.username;
    tempUser.email = this.form.value.email;
    tempUser.password = this.form.value.password;
    tempUser.displayName = this.form.value.displayName;

    var url = this.baseUrl + "api/user";

    this.http.post<UserRegistration>(url, tempUser).subscribe(res => {
        if (res) {                   
            this.sb.open("User " + res.userName + " has been created.", 'close', { duration: 5000 });
            // redirect to login page
            this.router.navigate(["login"]);
        }
        else {
            // registration failed
            this.sb.open('User registration failed.', 'close', { duration: 5000 });
        }
    }, error => {
        console.log(error);//de verificat
    });
  }

  onBack() {
      this.router.navigate([""]);
  }

  public get formOk(): boolean {
    return this.form.valid
  }

  ngOnInit() {
  }
}
