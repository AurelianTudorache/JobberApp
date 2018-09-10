import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SettingsRoutingModule } from './settings-routing.module';
import { SettingsPageComponent } from './settings-page/settings-page.component';
import { AuthGuard } from '../../shared/services/auth.guard';
import { CreditCardComponent } from './credit-card/credit-card.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginDetailsComponent } from './login-details/login-details.component';
import { BusinessDetailsComponent } from './business-details/business-details.component';
import { StaffComponent } from './staff/staff.component';
import { LocationsComponent } from './locations/locations.component';
import { DialogsService } from '../../shared/services/dialogs.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule,
    SettingsRoutingModule,
    AngularMaterialComponentsModule
  ],
  declarations: [SettingsPageComponent, CreditCardComponent, LoginDetailsComponent, BusinessDetailsComponent, StaffComponent, LocationsComponent],
  providers: [AuthGuard, DialogsService] 
})
export class SettingsModule { }
