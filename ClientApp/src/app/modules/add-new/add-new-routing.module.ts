import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddNewFormComponent } from './add-new-form/add-new-form.component';
import { AuthGuard } from '../../shared/services/auth.guard';

const routes: Routes = [
  { path: '', component: AddNewFormComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddNewRoutingModule { }
