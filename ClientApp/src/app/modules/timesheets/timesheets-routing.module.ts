import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimesheetsComponent } from './timesheets/timesheets.component';
import { AuthGuard } from '../../shared/services/auth.guard';

const routes: Routes = [
  { path: '', component: TimesheetsComponent, canActivate: [AuthGuard]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimesheetsRoutingModule { }
