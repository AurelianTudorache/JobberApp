import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotificationsListComponent } from './notifications-list/notifications-list.component';
import { AuthGuard } from '../../shared/services/auth.guard';

const routes: Routes = [
  { path: '', component: NotificationsListComponent, canActivate: [AuthGuard]},  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotificationsRoutingModule { }
