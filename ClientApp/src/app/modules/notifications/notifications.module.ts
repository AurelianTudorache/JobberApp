import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotificationsRoutingModule } from './notifications-routing.module';
import { NotificationsListComponent } from './notifications-list/notifications-list.component';
import { AuthGuard } from '../../shared/services/auth.guard';

@NgModule({
  imports: [
    CommonModule,
    NotificationsRoutingModule,
    AngularMaterialComponentsModule
  ],
  declarations: [NotificationsListComponent],
  providers: [AuthGuard]
})
export class NotificationsModule { }
