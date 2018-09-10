import { UserLogin } from './../../../shared/interfaces/user-login';
import { Component, OnInit, Inject } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../shared/services/auth.service';
import { FormFieldStateMatcher } from '../../../shared/modules/angular-material-components/formfield.statematcher';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    form: FormGroup;
  
    matcher = new FormFieldStateMatcher();
    public username = new FormControl('', [Validators.required]);
    public password = new FormControl('', [Validators.required]);

    constructor(private router: Router, private sb: MatSnackBar, private authService: AuthService, private fb: FormBuilder) {
        this.form = this.fb.group({
            username: this.username,
            password: this.password
        }); 
    }

    onSubmit() {       

        this.authService.login(this.form.value.username, this.form.value.password)
        .subscribe(res => {
            // login successful
            // alert("Login successful! "  + "USERNAME: "  + this.user.userName  + " TOKEN: "  + this.authService.getAuth()!.token);
            this.sb.open('You successfuly login.', 'close', { duration: 5000 });
            this.router.navigate(["add-new"]);
        },
        err => {
            // login failed
            this.sb.open('Incorrect username or password.', 'close', { duration: 5000 });
        });
    }

    public get formOk(): boolean {
        return this.form.valid;
    }

    ngOnInit(){}

}
