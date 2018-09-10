import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginFormRoutingModule } from './login-form-routing.module';
import { LoginComponent } from './login/login.component';
import { AuthService } from '../../shared/services/auth.service';


@NgModule({
  imports: [
    CommonModule,
    LoginFormRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AngularMaterialComponentsModule
  ],
  declarations: [LoginComponent],
  providers: [AuthService]
})
export class LoginFormModule { }
