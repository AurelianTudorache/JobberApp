import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddNewRoutingModule } from './add-new-routing.module';
import { AddNewFormComponent } from './add-new-form/add-new-form.component';
import { AuthGuard } from '../../shared/services/auth.guard';

@NgModule({
  imports: [
    CommonModule,
    AddNewRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    AngularMaterialComponentsModule
  ],
  declarations: [AddNewFormComponent],
  providers: [AuthGuard]
})
export class AddNewModule { }
