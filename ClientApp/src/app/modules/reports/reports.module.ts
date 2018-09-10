import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportsRoutingModule } from './reports-routing.module';
import { ReportsComponent } from './reports/reports.component';
import { AuthGuard } from '../../shared/services/auth.guard';

@NgModule({
  imports: [
    CommonModule,
    ReportsRoutingModule,
    AngularMaterialComponentsModule
  ],
  declarations: [ReportsComponent],
  providers: [AuthGuard]
})
export class ReportsModule { }
