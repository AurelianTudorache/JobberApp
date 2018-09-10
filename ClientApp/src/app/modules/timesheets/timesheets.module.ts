import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimesheetsRoutingModule } from './timesheets-routing.module';
import { TimesheetsComponent } from './timesheets/timesheets.component';
import { AuthGuard } from '../../shared/services/auth.guard';

@NgModule({
  imports: [
    CommonModule,
    TimesheetsRoutingModule,
    AngularMaterialComponentsModule
  ],
  declarations: [TimesheetsComponent],
  providers: [AuthGuard]
})
export class TimesheetsModule { }
