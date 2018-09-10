import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegistrationFormRoutingModule } from './registration-form-routing.module';
import { RegistrationComponent } from './registration/registration.component';
import { AngularMaterialComponentsModule } from '../../shared/modules/angular-material-components/angular-material-components.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule,
    RegistrationFormRoutingModule,
    HttpClientModule,
    AngularMaterialComponentsModule
  ],
  declarations: [RegistrationComponent]
})
export class RegistrationFormModule { }
