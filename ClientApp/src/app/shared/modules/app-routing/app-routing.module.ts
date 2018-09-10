import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'login', loadChildren: '../../../modules/login-form/login-form.module#LoginFormModule' },
  { path: 'register', loadChildren: '../../../modules/registration-form/registration-form.module#RegistrationFormModule' },

  { path: 'add-new', loadChildren: '../../../modules/add-new/add-new.module#AddNewModule' },
  { path: 'jobs', loadChildren: '../../../modules/jobs/jobs.module#JobsModule' },
  { path: 'messages', loadChildren: '../../../modules/messages/messages.module#MessagesModule' },
  { path: 'messages/:name', loadChildren: '../../../modules/messages/messages.module#MessagesModule' },
  { path: 'notifications', loadChildren: '../../../modules/notifications/notifications.module#NotificationsModule' },
  { path: 'reports', loadChildren: '../../../modules/reports/reports.module#ReportsModule' },
  { path: 'timesheets', loadChildren: '../../../modules/timesheets/timesheets.module#TimesheetsModule' },
  { path: 'settings', loadChildren: '../../../modules/settings/settings.module#SettingsModule' },
]

@NgModule({
  imports: [ RouterModule.forRoot(routes)],
  exports: [ RouterModule ],
  declarations: []
})
export class AppRoutingModule { }
